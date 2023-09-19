using TMPro;
using UnityEngine;

namespace Game.WheelOfFortune
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text earnedCoinText;
        
        public void ShowWinPanel(int earnedCoin)
        {
            earnedCoinText.SetText($"+ {earnedCoin} coin" );
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}