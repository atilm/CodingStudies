using System.Collections.Immutable;
using System.Linq;
using LogicGates.BasicComponents;
using LogicGates.LogicGates;

namespace LogicGates.FunctionalComponents.Counters
{
    public class NBitRippleCounter : IIndexedOutputs
    {
        public NBitRippleCounter(int bits)
        {
            _clockHub.ConnectSourceInput(Clock);
            _clockHub.ConnectTargetInput(_clockInverter.Input);

            var firstDivider = new FrequencyDivider();
            _clockHub.ConnectTargetInput(firstDivider.Input);

            var dividers = ImmutableList<FrequencyDivider>.Empty.Add(firstDivider);

            _dividers = Enumerable
                .Range(0, bits - 2)
                .Aggregate(dividers, ConnectNextDivider);
        }

        private static ImmutableList<FrequencyDivider> ConnectNextDivider(ImmutableList<FrequencyDivider> dividers, int _)
        {
            var divider = new FrequencyDivider();
            dividers.Last().QBar.Connect(divider.Input);
            return dividers.Add(divider);
        }

        public Input Clock { get; } = new();

        public Output Output(int index)
        {
            return index == 0 ? _clockInverter.Output : _dividers[index-1].Q;
        }

        private readonly InputWireHub _clockHub = new();
        private readonly Inverter _clockInverter = new();
        private readonly ImmutableList<FrequencyDivider> _dividers;
    }
}