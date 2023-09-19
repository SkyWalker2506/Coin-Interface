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
        public static Action<int> OnSelected;

        private void Awake()
        {
            baseColor = button.image.color;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(()=>OnSelected?.Invoke(betValue));
            OnSelected += OnButtonSelected;
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(()=>OnSelected?.Invoke(betValue));
            OnSelected -= OnButtonSelected;
        }
        
        public void SetButton(int value)
        {
            betValue = value;
            text.SetText(value.ToString());
        }
        
        private void OnButtonSelected(int index)
        {
            if (index == betValue)
            {
                button.image.color = selectedColor;
            }
            else
            {
                button.image.color = baseColor;
            }
        }
        
    }
}