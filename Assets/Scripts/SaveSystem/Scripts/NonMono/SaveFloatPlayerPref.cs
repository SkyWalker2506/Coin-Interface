using System.Globalization;

namespace SaveSystem
{
    public class SaveFloatPlayerPref : SaveDataPlayerPrefBase, IFloatSave
    {
        public SaveFloatPlayerPref(string key, float defaultValue = 0) : base(key, defaultValue.ToString(CultureInfo.InvariantCulture))
        {
        }
        
        public void Save(float value)
        {
            Value = value.ToString(CultureInfo.InvariantCulture);
            Save();
        }

        public float GetSavedFloat()
        {
            Load();
            return float.Parse(Value);
        }

    }
}