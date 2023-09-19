using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.WheelOfFortune
{
    public class BetSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text betText;
        public int Value => (int)slider.value;

        private void Awake()
        {
            OnSliderChanged(slider.value);
        }

        private void OnEnable()
        {
            slider.onValueChanged.AddListener(OnSliderChanged);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnSliderChanged);
        }

        private void OnSliderChanged(float value)
        {
            betText.SetText(value.ToString(CultureInfo.InvariantCulture));
        }

        public void SetSlider(int min, int max)
        {
            slider.minValue = min;
            slider.maxValue = max;
        }
    }
}