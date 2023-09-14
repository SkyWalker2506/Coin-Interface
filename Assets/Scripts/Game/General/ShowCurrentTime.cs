using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class ShowCurrentTime : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI currentTimeLabel;

    // Update is called once per frame
    void Update()
    {
        currentTimeLabel.text = TimerUtility.CurrentTime.ToString("F");
    }
}
