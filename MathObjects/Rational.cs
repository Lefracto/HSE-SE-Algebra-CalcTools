namespace MathObjects
{
    public class Rational
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
        public Rational Add(Rational rational)
        {
            Numerator = Numerator * rational.Denominator + rational.Numerator * Denominator;
            Denominator = Denominator * rational.Denominator;
            return this;
        }
        public Rational Minus(Rational rational)
        {
            Numerator = Numerator * rational.Denominator - rational.Numerator * Denominator;
            Denominator = Denominator * rational.Denominator;
            return this;
        }
        public Rational Multiply(Rational rational)
        {
            Numerator *= rational.Numerator;
            Denominator *= rational.Denominator;
            return this;
        }
        
        public override string ToString() => _denominator == 1
            ? _numerator.ToString()
            : _numerator + "/" + _denominator;
    }
}