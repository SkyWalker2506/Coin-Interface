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

        public DateTime GetSavedFloatData()
        {
            Load();
            return DateTime.Parse(Value);
        }
    }
    public class SaveFloatPlayerPref : SaveDataPlayerPrefBase, IFloatSaveData
    {
        public SaveFloatPlayerPref(string key, float defaultValue = 0) : base(key, defaultValue.ToString(CultureInfo.InvariantCulture))
        {
        }
        
        public void Save(float value)
        {
            Value = value.ToString(CultureInfo.InvariantCulture);
            Save();
        }

        public float GetSavedFloatData()
        {
            Load();
            return float.Parse(Value);
        }

    }
}