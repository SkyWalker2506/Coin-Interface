namespace SaveSystem
{
    public interface ISaveData
    {
        string Key { get; }
        string Value { get; }
        void Save();
        void Load();
        bool HasSavedData();
    }
}