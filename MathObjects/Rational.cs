﻿using System;
using Microsoft.VisualBasic.CompilerServices;

namespace MathObjects
{
    public class Rational : MatrixCellData
    {
        private int _numerator;
        private int _denominator;

        public int Numerator
        {
            get => _numerator;
            private set => _numerator = value;
        }

        public int Denominator
        {
            get => _denominator;
            private set => _denominator = value;
        }

        public Rational()
        {
            _numerator = 0;
            _denominator = 1;
        }

        public Rational(int numerator)
        {
            _numerator = numerator;
        }

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be 0");
            
            _numerator = numerator;
            _denominator = denominator;
            Reduce();
        }

        public override MatrixCellData GetInverseByAddition()
            => -this;

        private static int Gcd(int a, int b)
            => b == 0 ? a : Gcd(b, a % b);

        private void Reduce()
        {
            var gcd = Gcd(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }
        
        public override MatrixCellData Add(MatrixCellData data)
        {
            if (data is not Rational rational) 
                return null;
            
            Numerator = Numerator * rational.Denominator + rational.Numerator * Denominator;
            Denominator *= rational.Denominator;
            Reduce();
            return this;
        }
        public override MatrixCellData Minus(MatrixCellData data)
        {
            if (data is not Rational rational) 
                return null;
            
            Numerator = Numerator * rational.Denominator - rational.Numerator * Denominator;
            Denominator *= rational.Denominator;
            Reduce();
            return this;
        }
        
        public override MatrixCellData Multiply(MatrixCellData data)
        {
            if (data is not Rational rational) 
                return null;
            
            Numerator *= rational.Numerator;
            Denominator *= rational.Denominator;
            Reduce();
            return this;
        }
        
        public static Rational operator -(Rational rational)
        {
            rational._numerator *= -1;
            return rational;
        }

        public override MatrixCellData ReadCellData(string input)
        {
            var elements = input.Split('/');
            switch (elements.Length)
            {
                case 2 when int.TryParse(elements[0], out var numerator) && int.TryParse(input, out var denominator):
                    return new Rational(numerator, denominator);
                case 2:
                    //exception
                    break;
                case 1 when int.TryParse(input, out var numerator):
                    return new Rational(numerator);
                case 1:
                    //exception
                    break;
                default:
                    return null;
            }

            return null;
        }
        public override string ToString() => _denominator == 1
            ? _numerator.ToString()
            : _numerator + "/" + _denominator;
    }
}