using System;
using CurrencySystem;
using LogicSystem;
using SaveSystem;
using UnityEngine;

namespace Game.WheelOfFortune
{
    public class WheelOfFortuneController : MonoBehaviour
    {
        [SerializeField] private TrueFalseChance[] winLoseChart;
        [SerializeField] private BetPanel betPanel;
        [SerializeField] private WheelController wheelController;
        [SerializeField] private CurrencyController currencyController;
        [SerializeField] private LosePanel losePanel;
        [SerializeField] private WinPanel winPanel;
        private int playedCount;
        private string playedCountSaveKey = "Wheel Of Fortune Played Count";
        private IIntSave playedCountSaveData;
        private BetData selectedBetData;

        private void Awake()
        {
            playedCountSaveData = new SaveIntPlayerPref(playedCountSaveKey, playedCount);
            playedCount = playedCountSaveData.GetSavedInt();
        }

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
            losePanel.Close();
            winPanel.Close();
            betPanel.OnBetSelected += OnBetSelected;
            wheelController.OnWheelStopped += OnWheelStopped;
        }

        private void OnDisable()
        {
            betPanel.OnBetSelected -= OnBetSelected;
            wheelController.OnWheelStopped -= OnWheelStopped;
        }

        private void OnWheelStopped(int wheelNumber)
        {
            playedCount++;
            playedCountSaveData.Save(playedCount);
            if (wheelNumber == selectedBetData.Number)
            {
                Invoke(nameof(OnWin),1);
            }
            else
            {
                Invoke(nameof(OnLose),1);
            }
        }

        void OnLose()
        {
            losePanel.ShowLosePanel(selectedBetData.CoinBet);
            currencyController.Decrease(selectedBetData.CoinBet);
        }
        
        void OnWin()
        {
            winPanel.ShowWinPanel(selectedBetData.CoinBet*2);
            currencyController.Increase(selectedBetData.CoinBet*2);
        }

        private void OnBetSelected(BetData betData)
        {
            selectedBetData = betData;
            betPanel.gameObject.SetActive(false);
            wheelController.gameObject.SetActive(true);
            if (winLoseChart[Math.Min(playedCount,winLoseChart.Length-1)].GetResult())
            {
                wheelController.MoveToNumber(betData.Number);
            }
            else
            {
                wheelController.AvoidNumber(betData.Number);
            }
        }

        public void OpenBetPanel()
        {
            betPanel.Initialize((int)currencyController.Currency.Amount, wheelController.TotalNumber);
            betPanel.gameObject.SetActive(true);
            wheelController.gameObject.SetActive(false);
        }
    
        public void OpenWheelPanel()
        {

        }
        
        
    }
}