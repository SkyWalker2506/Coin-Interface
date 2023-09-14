using System;
using CurrencySystem;

namespace Game.CurrencySystem
{
    public class Gold : ICurrency
    {
        public float Amount { get; }
        public Action OnAmountUpdated { get; set; }
    }
}