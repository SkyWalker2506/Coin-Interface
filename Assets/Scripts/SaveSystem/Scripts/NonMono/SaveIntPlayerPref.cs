using System.Globalization;

namespace SaveSystem
{
    public class SaveIntPlayerPref : SaveDataPlayerPrefBase, IIntSaveData
    {
        public SaveIntPlayerPref(string key, string defaultValue = "") : base(key, defaultValue)
        {
        }

        public void Save(int value)
        {
            Value = value.ToString(CultureInfo.InvariantCulture);
            Save();
        }

        public int GetSavedInt()
        {
            return int.Parse(Value);
        }
    }
}