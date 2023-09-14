using System.Globalization;
using TMPro;
using UnityEngine;

namespace CurrencySystem
{
    public abstract class CurrencyUI : MonoBehaviour, ICurrencyUI
    {
        public virtual TMP_Text CurrencyText { get; }
        public virtual ICurrency Currency { get; }

        protected virtual void OnEnable()
        {
            Currency.OnAmountUpdated += UpdateUI;
        }

        protected virtual  void OnDisable()
        {
            Currency.OnAmountUpdated -= UpdateUI;
        }

        public virtual void UpdateUI()
        {
            CurrencyText.SetText(Currency.Amount.ToString(CultureInfo.InvariantCulture));
        }
    }
}