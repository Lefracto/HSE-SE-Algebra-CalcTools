using System;
using MathObjects;
using System.Linq;

namespace HSE_SE_Algebra_CalcTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Permutation(new int[]
            {
                1, 2, 3
            });
            
            Console.WriteLine(p.NextPermutation());
        }
    }
}