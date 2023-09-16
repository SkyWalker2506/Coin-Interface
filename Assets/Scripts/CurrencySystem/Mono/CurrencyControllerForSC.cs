using UnityEngine;

namespace CurrencySystem
{
    public abstract class CurrencyControllerForSC : CurrencyController
    {
        [SerializeField] private ScriptableCurrency currency;
        public override ICurrency Currency => currency;
    }
}