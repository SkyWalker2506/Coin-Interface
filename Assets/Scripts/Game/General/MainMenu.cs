using CurrencySystem;
using Game.TimeSystem;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BlockingWait blockingWaitPopup;
    [SerializeField] private CurrencyController currencyController;
    [SerializeField] private FreeCoinDailyEvent freeCoinDailyEvent;
    
    public void Action_SpendOneCoin()
    {
        currencyController.Decrease(1);
    }

    public void Action_GetExtraCoin()
    {
        blockingWaitPopup.gameObject.SetActive(true);
        currencyController.Increase(1);
    }

    public void Action_ClaimFreeCoin()
    {
        if (freeCoinDailyEvent.IsReadyToUse())
        {
            freeCoinDailyEvent.Use();
        }
    }
}