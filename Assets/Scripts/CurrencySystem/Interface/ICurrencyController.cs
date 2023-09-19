using System;

namespace CurrencySystem
{
    public interface ICurrencyController
    {
        ICurrency Currency { get; }
        void Set(float value);
        void Increase(float value);
        void Decrease(float value);
        Action OnCurrencyUpdated{ get; set; }
    }
}