using System;
using SaveSystem;
using TimeSystem;

namespace Game.TimeSystem
{
    public class SavableDailyEvent : DailyEvent
    {
        private string saveKey = "Last Called Event";
        private IDateTimeSaveData dateTimeSaveData;

        private void Awake()
        {
            dateTimeSaveData = new SaveDateTimePlayerPref(saveKey, LastUsedTime.ToString("t"));
            LastUsedTime = dateTimeSaveData.GetSavedFloatData();
        }

        public override void Use()
        {
            base.Use();
            dateTimeSaveData.Save(LastUsedTime);
        }
    }
}