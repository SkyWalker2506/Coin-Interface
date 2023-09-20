using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.WheelOfFortune
{
    public class BetButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;
        private Color baseColor;
        [SerializeField] private Color selectedColor;
        private int betValue;
        public Action<int> OnSelected;

        private void Awake()
        {
            baseColor = button.image.color;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(()=>OnSelected?.Invoke(betValue));
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(()=>OnSelected?.Invoke(betValue));
        }
        
        public void SetButton(int value)
        {
            betValue = value;
            text.SetText(value.ToString());
        }
        
        public void SetSelectedColor(bool isSelected)
        {
            button.image.color = isSelected? selectedColor:baseColor;
        }
        
    }
}