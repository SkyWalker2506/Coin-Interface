using UnityEngine;

namespace CurrencySystem
{
    public abstract class CurrencyManagerForSC : CurrencyManager
    {
        [SerializeField] private ScriptableCurrency currency;
        public override ICurrency Currency => currency;
    }
}