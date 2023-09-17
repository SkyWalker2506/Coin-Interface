using System;

namespace SaveSystem
{
    public interface IDateTimeSave 
    {
        public void Save(DateTime value);
        public DateTime GetSavedDateTime();
    }
}