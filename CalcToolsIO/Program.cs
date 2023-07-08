using System;
using MathObjects;

namespace HSE_SE_Algebra_CalcTools
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInt[][] v = new TestInt[2][];
            TestInt[][] v1 = new TestInt[2][];
            
            v[0] = new TestInt[2];
            v[0][0] = new TestInt(3);
            v[0][1] = new TestInt(5);
            
            v[1] = new TestInt[2];
            v[1][0] = new TestInt(3);
            v[1][1] = new TestInt(7);
            
            
            
            v1[0] = new TestInt[2];
            v1[0][0] = new TestInt(1);
            v1[0][1] = new TestInt(0);
            
            v1[1] = new TestInt[2];
            v1[1][0] = new TestInt(0);
            v1[1][1] = new TestInt(1);

            Matrix<TestInt> matrix = new Matrix<TestInt>(v);
            Matrix<TestInt> matrix2 = new Matrix<TestInt>(v1);
            
            Console.WriteLine(matrix);
            Console.WriteLine();
            Console.WriteLine(matrix2);
            Console.WriteLine();
            matrix.Transpose();
            Console.WriteLine(matrix);
        }
    }
}