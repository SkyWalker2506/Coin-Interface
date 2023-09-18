using System;
using LogicSystem;
using UnityEngine;

public class WheelOfFortune : MonoBehaviour
{
    [SerializeField] private TrueFalseChance[] winLoseChart;
    [SerializeField] private GameObject BetPanel;
    [SerializeField] private GameObject WheelPanel;

    private void OnValidate()
    {
        foreach (TrueFalseChance winLose in winLoseChart)
        {
            winLose.FalseChance = 100 - winLose.TrueChance;
        }
    }

    private void OnEnable()
    {
        OpenBetPanel();
    }

    public void OpenBetPanel()
    {
        BetPanel.SetActive(true);
        WheelPanel.SetActive(false);
    }
    
    public void OpenWheelPanel()
    {
        BetPanel.SetActive(false);
        WheelPanel.SetActive(true);
    }
    
}
