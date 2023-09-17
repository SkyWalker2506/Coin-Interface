namespace SaveSystem
{
    public interface IFloatSave 
    {
        public void Save(float value);
        public float GetSavedFloat();
    }
}