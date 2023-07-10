using System;

namespace MathObjects
{
    public class Module : MatrixCellData
    {
        private int _value;
        private readonly int _module;
        
        public Module()
        {
            _module = 0;
            _value = 0;
        }
        public Module(int value, int module)
        {
            if (module <= 0)
            {
                //exception
            }
            _module = module;
            Normilise();
            _value = value % _module;
        }

        private void Normilise()
        {
            while (_value < 0)
            {
                _value += _module;
            }
        }
        
        public override MatrixCellData GetInverseByAddition()
        {
            var inverse = _module - _value;
            return new Module(inverse, _module);
        }

        public override MatrixCellData Add(MatrixCellData data)
        {
            if (data is not Module module) 
                return null;

            if (module._module != _module)
            {
                //exception
            }

            _value += module._value;
            _value %= _module;
            return this;
        }
        
        public override MatrixCellData Multiply(MatrixCellData data)
        {
            if (data is not Module module) 
                return null;

            if (module._module != _module)
            {
                //exception
            }
            
            _value *= module._value;
            _value %= _module;
            return this;
        }

        public override MatrixCellData Minus(MatrixCellData data)
        {
            if (data is not Module module) 
                return null;

            if (module._module != _module)
            {
                //exception
            }
            
            _value -= module._value;
            Normilise();
            _value %= _module;
            return this;
        }

        public override MatrixCellData ReadCellData(string input)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => _value.ToString();
    }
}