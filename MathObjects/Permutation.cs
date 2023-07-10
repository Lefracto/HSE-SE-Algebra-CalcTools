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

        public int Sign => 1;

        public Permutation NextPermutation()
        {
            return this;
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
            {
                //exception
            }

            var composePermutation = new Permutation(permutation1.Size);
            for (int i = 0; i < permutation1.Size; i++)
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