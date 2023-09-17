using System.Globalization;

namespace SaveSystem
{
    public class SaveIntPlayerPref : SaveDataPlayerPrefBase, IIntSave
    {
        public SaveIntPlayerPref(string key, int defaultValue = 0) : base(key, defaultValue.ToString())
        {
        }

        public void Save(int value)
        {
            Value = value.ToString(CultureInfo.InvariantCulture);
            Save();
        }

        public int GetSavedInt()
        {
            Load();
            return int.Parse(Value);
        }
    }
}