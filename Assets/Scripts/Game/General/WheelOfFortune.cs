using LogicSystem;
using UnityEngine;

public class WheelOfFortune : MonoBehaviour
{
    [SerializeField] private TrueFalseChance[] winLoseChart;

    private void OnValidate()
    {
        foreach (TrueFalseChance winLose in winLoseChart)
        {
            winLose.FalseChance = 100 - winLose.TrueChance;
        }
    }
}
