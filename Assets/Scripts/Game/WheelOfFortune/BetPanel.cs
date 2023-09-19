using UnityEngine;

namespace Game.WheelOfFortune
{
    public class BetPanel : MonoBehaviour
    {
        [SerializeField] private BetButton betButtonPrefab;
        [SerializeField] private Transform buttonHolder;
        [SerializeField] private BetSlider betSlider;

        public void CreateBetButtons(int amount)
        {
            int childCount = buttonHolder.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(buttonHolder.GetChild(0).gameObject);
            }

            for (int i = 0; i < amount; i++)
            {
                Instantiate(betButtonPrefab, buttonHolder);
            }
        }
    }
}