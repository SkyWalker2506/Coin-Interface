using TMPro;
using UnityEngine;

namespace Game.WheelOfFortune
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text lostCoinText;
        
        public void ShowLosePanel(int lostCoin)
        {
            lostCoinText.SetText($"- {lostCoin} coin" );
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}