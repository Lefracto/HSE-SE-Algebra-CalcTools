using System;
using System.Linq;
using System.Text;

namespace MathObjects
{
    public class Permutation
    {
        private int[] _image;

        public int Size => _image.Length;
        
        public Permutation(int[] image)
        {
            _image = new int[image.Length];
            Array.Copy(image, _image, image.Length);
        }
        
        public Permutation(int size)
        {
            _image = new int[size];
        }

        public int Sign
        {
            get
            {
                var countInversions = 0;
                for (var i = 0; i < _image.Length; i++)
                {
                    for (var j = i; j < _image.Length; j++)
                    {
                        if (_image[i] > _image[j])
                            countInversions++;
                    }
                }

                return (int)Math.Pow(-1, countInversions);
            }
        }
        
        private static int IndexOfMin(int[] array, int i, int minValue)
        {
            var index = i;
            for (var j = i; j < array.Length; j++) {
                if (array[j] <= array[index] && array[j] > minValue) {
                    index = j;
                }
            }
            return index;
        }
        
        public Permutation NextPermutation()
        {
            var newImage = new int[_image.Length];
            Array.Copy(_image, newImage, _image.Length);
            
            for(var i = newImage.Length - 1; i > 0; --i)
            {
                if (newImage[i] <= newImage[i - 1]) continue;
                (newImage[i - 1], newImage[IndexOfMin(newImage, i, newImage[i - 1])]) =
                    (newImage[IndexOfMin(newImage, i, newImage[i - 1])], newImage[i - 1]);
                Array.Sort(newImage, i, newImage.Length - i); 
                break;
            }
            return new Permutation(newImage);
        }

        public Permutation GetInversedPermutation()
        {
            var reversedImage = new int[Size];
            for (var i = 0; i < Size; i++)
            {
                reversedImage[i] = Array.IndexOf(_image, i + 1) + 1;
            }
            return new Permutation(reversedImage);
        }
        
        public static Permutation operator* (Permutation permutation1, Permutation permutation2)
        {
            if (permutation1.Size != permutation2.Size)
                throw new ArgumentException("You cannot compose permutations with different sizes");

            var composePermutation = new Permutation(permutation1.Size);
            for (var i = 0; i < permutation1.Size; i++)
            {
                composePermutation._image[i] = permutation2._image[permutation1._image[i] - 1];
            }
            
            return composePermutation;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("/" + string.Join(" ", Enumerable.Range(1, Size).Select(i => i.ToString()))  + "\\\n");
            sb.Append("\\" + string.Join(" ", _image.Select(x => x.ToString()).ToArray()) + "/\n");
            return sb.ToString();
        }
    }
}