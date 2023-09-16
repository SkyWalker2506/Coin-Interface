using System.Globalization;
using SaveSystem;

namespace Game.TimeSystem
{
    public class AdDailyEvent : SavableDailyEvent
    {
        private string saveKey = "Called Event Amount";
        private IIntSaveData calledAmountSaveData;
        private int calledAmount;
        private void Awake()
        {
            calledAmountSaveData = new SaveIntPlayerPref(saveKey, 0.ToString(CultureInfo.InvariantCulture));
            calledAmount = calledAmountSaveData.GetSavedInt();
        }

        public override void Use()
        {
            Use();
            calledAmount++;
            calledAmountSaveData.Save(calledAmount);
        }
    }
}