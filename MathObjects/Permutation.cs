using System.Collections.Generic;
using System.Security.Cryptography;

namespace MathObjects
{
    public class Permutation
    {
        private List<int> _image;

        public int Size => _image.Count;
        
        public Permutation(int[] image)
        {
            _image = new List<int>(image);
        }

        public Permutation(List<int> image)
        {
            _image = new List<int>(image);
        }

        public Permutation(int size)
        {
            
        }

        public int Sign => 1;

        public Permutation NextPermutation()
        {
            return this;
        }

        public Permutation GetInversedPermutation()
        {
            return this;
        }
        
        public static Permutation operator* (Permutation permutation1, Permutation permutation2)
        {
            return permutation1;
        }
    }
}