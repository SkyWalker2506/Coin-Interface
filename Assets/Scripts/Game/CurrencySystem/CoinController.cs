using CurrencySystem;
using SaveSystem;
using UnityEngine;

namespace Game.CurrencySystem
{
    public class CoinController : CurrencyControllerForSC
    {
        [SerializeField] private string saveKey = "Coin";
        [SerializeField] private float defaultCoinAmount;
        private IFloatSaveData saveData;

        private void Awake()
        {
            saveData = new SaveFloatPlayerPref(saveKey, defaultCoinAmount);
            Set(saveData.GetSavedFloatData());
        }

        public override void Set(float value)
        {
            base.Set(value);
            saveData.Save(value);
        }
    }
}