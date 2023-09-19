using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.WheelOfFortune
{
    public class BetSlider : MonoBehaviour
    {
        [SerializeField] private Slider betSlider;
        [SerializeField] private TMP_Text betText;

        private void Awake()
        {
            OnSliderChanged(betSlider.value);
        }

        private void OnEnable()
        {
            betSlider.onValueChanged.AddListener(OnSliderChanged);
        }

        private void OnDisable()
        {
            betSlider.onValueChanged.RemoveListener(OnSliderChanged);
        }

        private void OnSliderChanged(float value)
        {
            betText.SetText(value.ToString(CultureInfo.InvariantCulture));
        }
        
    }
}