namespace SaveSystem
{
    public interface IFloatSaveData 
    {
        public void Save(float value);
        public float GetSavedFloat();
    }
}