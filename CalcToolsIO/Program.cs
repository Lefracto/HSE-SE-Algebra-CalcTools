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
                4, 1, 5, 3, 2
            });

            Rational r = new Rational(3, 5);
            
            Console.WriteLine(r);
        }
    }
}