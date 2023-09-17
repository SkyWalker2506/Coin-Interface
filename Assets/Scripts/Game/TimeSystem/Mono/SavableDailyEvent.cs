using System.Globalization;
using SaveSystem;
using TimeSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.TimeSystem
{
    public class SavableDailyEvent : DailyEvent
    {
        public string SaveKey="";
        private string lastUsedTimeSaveKey=>$"{SaveKey} Last Used Time";
        private string usedAmountSaveKey=>$"{SaveKey} Used Amount";
        private IDateTimeSave dateTimeSave;
        private IIntSave usedAmountSave;

        protected override void Awake()
        {
            dateTimeSave = new SaveDateTimePlayerPref(lastUsedTimeSaveKey, LastUsedTime);
            LastUsedTime = dateTimeSave.GetSavedDateTime();
            usedAmountSave = new SaveIntPlayerPref(usedAmountSaveKey, 0);
            UsedAmount = usedAmountSave.GetSavedInt();
            base.Awake();
        }

        public override void Use()
        {
            base.Use();
            dateTimeSave.Save(LastUsedTime);
            usedAmountSave.Save(UsedAmount);
        }

        protected override void ResetUsedAmount()
        {
            base.ResetUsedAmount();
            usedAmountSave.Save(UsedAmount);
        }
    }
}
