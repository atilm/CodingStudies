using LogicGates.BasicComponents;

namespace LogicGates.FunctionalComponents.Counters
{
    public class NBitRippleCounter : IIndexedOutputs
    {
        public NBitRippleCounter(int bits)
        {
            
        }

        public Input Clock { get; } = new();

        public Output Output(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}