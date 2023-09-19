using CurrencySystem;
using Game.TimeSystem;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BlockingWait blockingWaitPopup;
    [SerializeField] private CurrencyController currencyController;
    [SerializeField] private SavableDailyEvent extraCoinEvent;
    [SerializeField] private SavableDailyEvent freeCoinEvent;
    [SerializeField] private Button extraCoinButton;
    [SerializeField] private Button freeCoinButton;
    [SerializeField] private Button miniGameButton;

    private void OnEnable()
    {
        blockingWaitPopup.OnBlockingDone+=OnBlockingDone;
        extraCoinEvent.OnRenewal += OnExtraCoinRenewal;
        extraCoinEvent.OnDailyLimitEnded += OnExtraCoinDailyLimitEnded;
        freeCoinEvent.OnRenewal += OnFreeCoinRenewal;
        freeCoinEvent.OnDailyLimitEnded += OnFreeCoinDailyLimitEnded;
        currencyController.OnCurrencyUpdated += OnCurrencyUpdated;
    }

    private void OnDisable()
    {
        blockingWaitPopup.OnBlockingDone-=OnBlockingDone;
        extraCoinEvent.OnRenewal -= OnExtraCoinRenewal;
        extraCoinEvent.OnDailyLimitEnded -= OnExtraCoinDailyLimitEnded;
        freeCoinEvent.OnRenewal -= OnFreeCoinRenewal;
        freeCoinEvent.OnDailyLimitEnded -= OnFreeCoinDailyLimitEnded;
        currencyController.OnCurrencyUpdated -= OnCurrencyUpdated;
    }

    private void OnExtraCoinRenewal()
    {
        extraCoinButton.interactable = true;
    }
    
    private void OnExtraCoinDailyLimitEnded()
    {
        extraCoinButton.interactable = false;
    }
    private void OnFreeCoinRenewal()
    {
        freeCoinButton.interactable = true;
    }
    private void OnFreeCoinDailyLimitEnded()
    {
        freeCoinButton.interactable = false;
    }
    
    public void Action_SpendOneCoin()
    {
        currencyController.Decrease(1);
    }

    public void Action_GetExtraCoin()
    {
        if (extraCoinEvent.IsReadyToUse())
        {
            blockingWaitPopup.gameObject.SetActive(true);
        }
    }

    void OnBlockingDone()
    {
        extraCoinEvent.Use();
        currencyController.Increase(1);
    }

    public void Action_ClaimFreeCoin()
    {
        if (freeCoinEvent.IsReadyToUse())
        {
            freeCoinEvent.Use();
            currencyController.Increase(1);
        }
    }

    private void OnCurrencyUpdated()
    {
        miniGameButton.interactable = currencyController.Currency.Amount > 0;
    }
}