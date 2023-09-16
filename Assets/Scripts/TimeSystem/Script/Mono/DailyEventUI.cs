using System;
using TMPro;
using UnityEngine;

namespace TimeSystem
{
    public class DailyEventUI : MonoBehaviour
    {
        [SerializeField] private DailyEvent dailyEvent;
        [SerializeField] private TMP_Text eventText;
        [field:SerializeField] protected string availableEventText { get; set; }

        private void Update()
        {
            if (dailyEvent.IsReadyToUse())
            {
                eventText.SetText(availableEventText);
            }
            else
            {
                eventText.SetText(dailyEvent.GetRemainingTime().ToString());
            }
        }
    }
}