using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LogicSystem
{
    [Serializable]
    public class TrueFalseChance : ITrueFalseChance
    {
        [field:Range(0f,100f)][field: SerializeField] public float TrueChance { get; set; } = 50;
        [field:Range(0f,100f)][field:SerializeField] public float FalseChance { get; set; }= 50;

        public bool GetResult()
        {
            return TrueChance > Random.Range(0, TrueChance + FalseChance);
        }
    }
}