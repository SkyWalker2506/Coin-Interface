using System;
using TMPro;
using UnityEngine;

namespace TimeSystem
{
    public class DailyEventUI : MonoBehaviour
    {
        [SerializeField] private DailyEvent dailyEvent;
        [SerializeField] private TMP_Text eventText;
        string initialText { get; set; }

        private void Awake()
        {
            initialText = eventText.text;
        }

        private void OnEnable()
        {
            dailyEvent.OnTick += UpdateUI;
            dailyEvent.OnRenewal += UpdateUIAfterRenewal;
        }

        private void OnDisable()
        {
            dailyEvent.OnTick -= UpdateUI;
            dailyEvent.OnRenewal -= UpdateUIAfterRenewal;
        }

        private void UpdateUI()
        {
            if (dailyEvent.IsReadyToUse())
            {
                return;
            }
            eventText.SetText(dailyEvent.GetRemainingTime().ToString().Split(".")[0]);
        }
        
        private void UpdateUIAfterRenewal()
        {
                eventText.SetText(initialText);
        }
    }
}