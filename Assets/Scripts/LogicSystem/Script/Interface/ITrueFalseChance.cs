
namespace LogicSystem
{
    public interface ITrueFalseChance 
    {
        float TrueChance { get; }
        float FalseChance { get; }
        bool GetResult();
    }
}
