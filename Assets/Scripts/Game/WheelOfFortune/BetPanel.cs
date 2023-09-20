using System;
using UnityEngine;

namespace Game.WheelOfFortune
{
    public class BetPanel : MonoBehaviour
    {
        [SerializeField] private BetButton betButtonPrefab;
        [SerializeField] private Transform buttonHolder;
        [SerializeField] private BetSlider betSlider;
        private BetButton[] betButtons = Array.Empty<BetButton>();
        public Action<BetData> OnBetSelected;
        private int selectedNumber;
        public void Initialize(int coinAmount,int totalNumber)
        {
            betSlider.SetSlider(1, coinAmount);
            CreateBetButtons(totalNumber);
        }

        public void CreateBetButtons(int amount)
        {
            foreach (BetButton betButton in betButtons)
            {
                betButton.OnSelected -= OnNumberSelected;
                Destroy(betButton.gameObject);
            }
            betButtons = new BetButton[amount];
            selectedNumber = 0;
            for (int i = 0; i < amount; i++)
            {
                BetButton betButton = Instantiate(betButtonPrefab, buttonHolder);
                betButton.SetButton(i+1);
                betButtons[i] = betButton;
                betButtons[i].OnSelected += OnNumberSelected;
            }
        }

        void OnNumberSelected(int number)
        {
            if (selectedNumber > 0)
            {
                betButtons[selectedNumber-1].SetSelectedColor(false);
            }
            selectedNumber = number;
            betButtons[selectedNumber-1].SetSelectedColor(true);
        }
        
        public void SelectBet()
        {
            OnBetSelected?.Invoke(new BetData(selectedNumber,betSlider.Value));
        } 
    }
}