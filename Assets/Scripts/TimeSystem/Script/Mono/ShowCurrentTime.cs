using TimeSystem;
using UnityEngine;
using TMPro;


namespace TimeSystem
{
    public class ShowCurrentTime : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI currentTimeLabel;

        void Update()
        {
            currentTimeLabel.text = TimerUtility.CurrentTime.ToString("F");
        }
    }
}
