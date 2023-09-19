using System;
using UnityEngine;

namespace CurrencySystem
{
    public abstract class CurrencyController : MonoBehaviour, ICurrencyController
    {
        public virtual ICurrency Currency { get; protected set; }
        public Action OnCurrencyUpdated { get; set; }

        private void OnEnable()
        {
            Currency.OnAmountUpdated += ()=>OnCurrencyUpdated?.Invoke();
        }

        private void OnDisable()
        {
            Currency.OnAmountUpdated -= ()=>OnCurrencyUpdated?.Invoke();
        }

        public virtual void Set(float value)
        {
            Currency.Amount = Mathf.Clamp(value,Currency.Min,Currency.Max);
            Currency.OnAmountUpdated?.Invoke();
        }

        public virtual void Increase(float value)
        {
            Set(Currency.Amount + value);
        }

        public virtual void Decrease(float value)
        {
            Set(Currency.Amount - value);
        }

    }
    
    
    
}