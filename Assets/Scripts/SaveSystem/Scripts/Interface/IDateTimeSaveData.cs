using System;

namespace SaveSystem
{
    public interface IDateTimeSaveData 
    {
        public void Save(DateTime value);
        public DateTime GetSavedDateTime();
    }
}