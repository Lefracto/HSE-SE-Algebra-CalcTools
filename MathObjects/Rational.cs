using System.Text;

namespace MathObjects
{
    public class Rational
    {
        private int _numerator;
        private int _denumerator;

        public Rational()
        {
            _numerator = 0;
            _denumerator = 1;
        }

        public Rational(int num, int denum)
        {
            _numerator = num;

            if (denum == 0)
            {
                //exception;
            }
            
            _denumerator = denum;
        }
        
        
        
        public override string ToString() => _denumerator == 1
            ? _numerator.ToString()
            : _numerator.ToString() + "/" + _denumerator.ToString();
    }
}