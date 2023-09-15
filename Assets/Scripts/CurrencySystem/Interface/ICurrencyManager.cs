namespace CurrencySystem
{
    public interface ICurrencyManager
    {
        ICurrency Currency { get; }
        void Set(float value);
        void Increase(float value);
        void Decrease(float value);
    }
}