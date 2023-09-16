using System;

namespace SaveSystem
{
    public interface IIntSaveData 
    {
        public void Save(int value);
        public int GetSavedInt();
    }
}