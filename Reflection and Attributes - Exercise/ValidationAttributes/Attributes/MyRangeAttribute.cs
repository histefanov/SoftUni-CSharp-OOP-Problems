using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Models;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int _minValue, int _maxValue)
        {
            this.minValue = _minValue;
            this.maxValue = _maxValue;
        }

        public override bool IsValid(object obj)
        {
            return (int)obj >= minValue && (int)obj <= maxValue;          
        }
    }
}
