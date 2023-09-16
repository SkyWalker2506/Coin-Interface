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

        private void Update()
        {
            if (dailyEvent.IsReadyToUse())
            {
                eventText.SetText(initialText);
            }
            else
            {
                eventText.SetText(dailyEvent.GetRemainingTime().ToString().Split(".")[0]);
            }
        }
    }
}