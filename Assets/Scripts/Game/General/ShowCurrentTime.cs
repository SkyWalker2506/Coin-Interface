using UnityEngine;
using TMPro;

public class ShowCurrentTime : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI currentTimeLabel;

    void Update()
    {
        currentTimeLabel.text = TimerUtility.CurrentTime.ToString("F");
    }
}
