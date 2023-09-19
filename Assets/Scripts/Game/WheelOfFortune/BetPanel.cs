using System;
using UnityEngine;

namespace Game.WheelOfFortune
{
    public class BetPanel : MonoBehaviour
    {
        [SerializeField] private BetButton betButtonPrefab;
        [SerializeField] private Transform buttonHolder;
        [SerializeField] private BetSlider betSlider;
        public Action<BetData> OnBetSelected;
        private int selectedNumber;
        public void Initialize(int coinAmount,int totalNumber)
        {
            betSlider.SetSlider(1, coinAmount);
            CreateBetButtons(totalNumber);
        }

        private void OnEnable()
        {
            BetButton.OnSelected += OnNumberSelected;
        }

        private void OnDisable()
        {
            BetButton.OnSelected -= OnNumberSelected;
        }

        public void CreateBetButtons(int amount)
        {
            int childCount = buttonHolder.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(buttonHolder.GetChild(i).gameObject);
            }

            for (int i = 0; i < amount; i++)
            {
                BetButton betButton = Instantiate(betButtonPrefab, buttonHolder);
                betButton.SetButton(i+1);
            }
        }

        void OnNumberSelected(int number)
        {
            selectedNumber = number;
        }
        
        public void SelectBet()
        {
            OnBetSelected?.Invoke(new BetData(selectedNumber,betSlider.Value));
        } 
    }
}