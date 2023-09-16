using System;
using System.Globalization;

namespace SaveSystem
{
    public class SaveDateTimePlayerPref : SaveDataPlayerPrefBase, IDateTimeSaveData
    {
        public SaveDateTimePlayerPref(string key, string defaultValue = "") : base(key, defaultValue)
        {
        }

        public void Save(DateTime value)
        {
            Value = value.ToString(CultureInfo.InvariantCulture);
            Save();
        }

        public DateTime GetSavedDateTime()
        {
            Load();
            return DateTime.Parse(Value);
        }
    }
}