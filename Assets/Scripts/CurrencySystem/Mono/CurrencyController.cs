using UnityEngine;

namespace CurrencySystem
{
    public abstract class CurrencyController : MonoBehaviour, ICurrencyController
    {
        public virtual ICurrency Currency { get; protected set; }

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