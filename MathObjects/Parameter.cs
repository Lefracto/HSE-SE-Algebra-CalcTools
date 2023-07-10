namespace MathObjects
{
    public class Parameter
    {
        private const string StandartName = "t";
        private readonly string _name;
        
        private static int CountStandartParameters;
        private bool _hasStandartName;

        public Parameter(string name)
        {
            _name = name;
            _hasStandartName = false;
        }

        public Parameter()
        {
            _hasStandartName = true;
            if (CountStandartParameters == 0)
            {
                _name = StandartName;
            }
            else
            {
                _name = StandartName + "_" + CountStandartParameters;
            }
            CountStandartParameters++;
        }

        ~Parameter()
        {
            if (_hasStandartName)
            {
                CountStandartParameters--;
            }    
        }
    }
}