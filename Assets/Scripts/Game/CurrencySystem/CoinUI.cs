using System.Globalization;
using CurrencySystem;

namespace Game.CurrencySystem
{
    public class CoinUI : CurrencyUIForSC
    {

        public override void UpdateUI()
        {
            CurrencyText.SetText($"Coins: {Currency.Amount}/{Currency.Max}");
        }
    }
}