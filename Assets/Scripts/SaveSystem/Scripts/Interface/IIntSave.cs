using System;

namespace SaveSystem
{
    public interface IIntSave 
    {
        public void Save(int value);
        public int GetSavedInt();
    }
}