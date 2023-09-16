using UnityEngine;

namespace SaveSystem
{
    public abstract class SaveDataPlayerPrefBase : ISaveData 
    {
        public string Key { get; }
        public string Value { get; protected set;}

        protected SaveDataPlayerPrefBase(string key, string defaultValue = "")
        {
            Key = key;
            if (!HasSavedData())
            {
                Value = defaultValue;
                Save();
            }
        }

        
        public virtual void Save()
        {
            PlayerPrefs.SetString(Key,Value);
        }

        public virtual void Load()
        {
            Value = PlayerPrefs.GetString(Key, Value);
        }

        public bool HasSavedData()
        {
            return PlayerPrefs.HasKey(Key);
        }
    }
}