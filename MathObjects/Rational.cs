using System.Text;

namespace MathObjects
{
    public class Rational
    {
        private int _numerator;
        private int _denominator;
        public int Numerator
        {
            get => _numerator;
          //  private set => _numerator = value;
        }
        
        public int Denominator
        {
            get => _denominator;
            //private set => _denominator = value;
        }
        
        public Rational()
        {
            _numerator = 0;
            _denominator = 1;
        }

        public Rational(int numerator, int denominator)
        {
            // make shorter
            
            if (denominator == 0)
            {
                //exception;
            }
            _numerator = numerator;
            _denominator = denominator;
        }
        
        public Rational Add(Rational rational) => new Rational(
            _numerator * rational._denominator + rational._numerator * _denominator,
            _denominator * rational._denominator);
        
        public Rational Minus(Rational rational) => new Rational(
            _numerator * rational._denominator - rational._numerator * _denominator,
            _denominator * rational._denominator);
        
        public Rational Multiply(Rational rational) => new Rational(
            _numerator * rational._numerator,
            _denominator * rational._denominator);
        
        public override string ToString() => _denominator == 1
            ? _numerator.ToString()
            : _numerator + "/" + _denominator;
    }
}