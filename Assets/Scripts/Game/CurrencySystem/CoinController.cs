using CurrencySystem;
using SaveSystem;
using UnityEngine;

namespace Game.CurrencySystem
{
    public class CoinController : CurrencyControllerForSC
    {
        [SerializeField] private string saveKey = "Coin";
        [SerializeField] private float defaultCoinAmount;
        private IFloatSave _save;

        private void Awake()
        {
            _save = new SaveFloatPlayerPref(saveKey, defaultCoinAmount);
        }

        private void Start()
        {
            Set(_save.GetSavedFloat());
        }

        public override void Set(float value)
        {
            base.Set(value);
            _save.Save(value);
        }
    }
}