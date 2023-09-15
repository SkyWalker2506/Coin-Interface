using System;

namespace CurrencySystem
{
    public abstract class Currency : ICurrency
    {
        public float Amount { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public Action OnAmountUpdated { get; set; }

        protected Currency(float amount, float min = 0, float max = float.MaxValue)
        {
            Amount = amount;
            Min = min;
            Max = max;
        }
    }
}