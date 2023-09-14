using System;

namespace CurrencySystem
{
    public interface ICurrency
    {
        float Amount { get; }
        Action OnAmountUpdated{ get; set; }
    }
}