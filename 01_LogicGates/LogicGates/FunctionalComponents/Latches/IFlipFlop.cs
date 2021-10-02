using LogicGates.BasicComponents;

namespace LogicGates.FunctionalComponents.Latches
{
    public interface IFlipFlop
    {
        Output Q { get; }
        Output QBar { get; }
    }
}