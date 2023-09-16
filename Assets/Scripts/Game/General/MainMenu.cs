using CurrencySystem;
using Game.TimeSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BlockingWait blockingWaitPopup;
    [SerializeField] private CurrencyController currencyController;
    [SerializeField] private SavableDailyEvent savableDailyEvent;
    
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
        if (savableDailyEvent.IsReadyToUse())
        {
            savableDailyEvent.Use();
            currencyController.Increase(1);
        }
    }
}