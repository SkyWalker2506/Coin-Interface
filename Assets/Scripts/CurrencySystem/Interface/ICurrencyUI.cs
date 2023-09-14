using TMPro;

namespace CurrencySystem
{
    public interface ICurrencyUI
    {
        TMP_Text CurrencyText { get; }
        ICurrency Currency { get; }
        void UpdateUI();
    }
}