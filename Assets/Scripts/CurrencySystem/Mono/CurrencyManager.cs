using UnityEngine;

namespace CurrencySystem
{
    public abstract class CurrencyManager :MonoBehaviour, ICurrencyManager
    {
        public ICurrency Currency { get; }
    }
    
    
}