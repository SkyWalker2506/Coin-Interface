using UnityEngine;

namespace CurrencySystem
{
    public abstract class CurrencyUIForSC : CurrencyUI
    {
        [SerializeField] private ScriptableCurrency currency;
        public override ICurrency Currency => currency;
    }
}