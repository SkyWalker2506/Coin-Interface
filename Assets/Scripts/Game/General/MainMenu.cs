using CurrencySystem;
using Game.TimeSystem;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BlockingWait blockingWaitPopup;
    [SerializeField] private CurrencyController currencyController;
    [SerializeField] private SavableDailyEvent savableDailyEvent;


    private void OnEnable()
    {
        blockingWaitPopup.OnBlockingDone+=OnBlockingDone;
    }

    private void OnDisable()
    {
        blockingWaitPopup.OnBlockingDone-=OnBlockingDone;
    }

    public void Action_SpendOneCoin()
    {
        currencyController.Decrease(1);
    }

    public void Action_GetExtraCoin()
    {
        blockingWaitPopup.gameObject.SetActive(true);
    }

    void OnBlockingDone()
    {
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