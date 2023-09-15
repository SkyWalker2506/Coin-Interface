using System;

namespace CurrencySystem
{
    public interface ICurrency
    {
        float Amount { get; set; }
        float Min { get; }
        float Max { get; }
        Action OnAmountUpdated{ get; set; }
    }
}