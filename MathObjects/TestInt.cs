using System;

namespace MathObjects
{
    public class TestInt : MatrixCellData
    {
        private int _value;
        public override MatrixCellData GetInverseByAddition() => new TestInt(-_value);
        public override MatrixCellData Add(MatrixCellData data)
        {
            if (data is TestInt testInt)
            {
                return new TestInt(_value + testInt._value);
            }
            return null;
        }
        public override MatrixCellData Multiply(MatrixCellData data)
        {
            if (data is TestInt testInt)
            {
                return new TestInt(_value * testInt._value);
            }
            return null;
        }
        
        public override MatrixCellData Minus(MatrixCellData data)
        {
            if (data is TestInt testInt)
            {
                return new TestInt(_value - testInt._value);
            }
            return null;
        }
        public override MatrixCellData ReadCellData(string input)
        {
            _value = Convert.ToInt32(input);
            return this;
        }
        public TestInt(int value)
        {
            _value = value;
        }

        public override string ToString() => _value.ToString();
    }
}