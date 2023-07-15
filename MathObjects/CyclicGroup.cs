using System;

namespace MathObjects
{
    public class CyclicGroup
    {
        private int _order;
        
        public CyclicGroup(int order)
        {
            if (order <= 0)
                throw new ArgumentException("Period must be >0");
            _order = order;
        }

        public int GetOrderOfElement(int element)
        {
            if (element < 0 || element > _order)
                throw new ArgumentException("This group doesn't have such element");

            var elementOrder = 0;
            var sum = element;
            while (sum != 0)
            {
                sum += element;
                elementOrder++;
            }
            
            return elementOrder;
        }
    }
}