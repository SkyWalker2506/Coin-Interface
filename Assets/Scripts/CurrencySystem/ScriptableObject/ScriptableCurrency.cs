using System;
using UnityEngine;

namespace CurrencySystem
{
    [CreateAssetMenu(menuName = "Create Scriptable Currency", fileName = "Scriptable Currency")]
    public class ScriptableCurrency : ScriptableObject, ICurrency
    {
        [field:SerializeField] public float Amount { get; set; }
        [field:SerializeField] public float Min { get; set; }
        [field:SerializeField] public float Max { get; set; }
        public Action OnAmountUpdated { get; set; }

    }
}