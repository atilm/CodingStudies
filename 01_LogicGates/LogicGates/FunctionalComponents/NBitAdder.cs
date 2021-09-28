using System.Collections.Immutable;
using System.Linq;
using LogicGates.BasicComponents;

namespace LogicGates.FunctionalComponents
{
    public class NBitAdder
    {
        public NBitAdder(int bitCount)
        {
            var firstAdder = new FullAdder();
            CarryIn = firstAdder.CarryIn;

            _adders = Enumerable.Range(0, bitCount-1)
                .Aggregate(ImmutableList<FullAdder>.Empty.Add(firstAdder), ConnectAnotherAdder);

            CarryOut = _adders.Last().Carry;
        }

        private ImmutableList<FullAdder> ConnectAnotherAdder(ImmutableList<FullAdder> adders, int index)
        {
            var adder = new FullAdder();
            adders.Last().Carry.Connect(adder.CarryIn);
            return adders.Add(adder);
        }

        public Input CarryIn { get; }
        
        public Output CarryOut { get; }

        public Input InputA(int index)
        {
            return _adders[index].InputA;
        }

        public Input InputB(int index)
        {
            return _adders[index].InputB;
        }

        public Output Output(int index)
        {
            return _adders[index].Sum;
        }

        private readonly ImmutableList<FullAdder> _adders;
    }
}