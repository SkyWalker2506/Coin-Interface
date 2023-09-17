using System;
using System.Globalization;

namespace SaveSystem
{
    public class SaveDateTimePlayerPref : SaveDataPlayerPrefBase, IDateTimeSave
    {
        public SaveDateTimePlayerPref(string key, DateTime defaultValue = new DateTime()) : base(key, defaultValue.ToString(CultureInfo.InvariantCulture))
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