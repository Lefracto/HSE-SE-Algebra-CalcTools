using System;

namespace MathObjects
{
    public class Module
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
            while (value < 0)
            {
                value += module;
            }
            _value = value % _module;
        }
        public Module GetInverseByAddition()
        {
            var inverse = _module - _value;
            while (inverse < 0)
            {
                inverse += _module;
            }

            return new Module(inverse, _module);
        }
        public Module Add(Module module)
        {
            _value = module._value + _value;
            return this;
        }
        public Module Multiply(Module module) 
        {
            _value = module._value * _value;
            return this;
        }
        public Module Minus(Module module)
        {
            _value = module._value - _value;
            return this;
        }
        
        public override string ToString() => _value.ToString();
    }
}