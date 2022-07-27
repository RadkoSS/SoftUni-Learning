namespace ValidationAttributes.Utilities.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _minValue;

        private readonly int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int number))
            {
                return false;
            }

            return number >= this._minValue && number <= this._maxValue;
        }
    }
}
