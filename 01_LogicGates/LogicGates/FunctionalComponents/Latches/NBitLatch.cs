using System.Collections.Generic;
using System.Linq;
using LogicGates.BasicComponents;

namespace LogicGates.FunctionalComponents.Latches
{
    public class NBitLatch
    {
        public NBitLatch(int bits)
        {
            _clockHub.ConnectSourceInput(Clock);

            _flipFlops = Enumerable.Range(0, bits)
                .Select(CreateFlipFlop)
                .ToList();
        }

        public Input Clock { get; } = new();

        public Input Input(int index)
        {
            return _flipFlops[index].Data;
        }

        public Output Output(int index)
        {
            return _flipFlops[index].Q;
        }
        
        private LevelTriggeredDataFlipFlop CreateFlipFlop(int _)
        {
            var flipFlop = new LevelTriggeredDataFlipFlop();
            _clockHub.ConnectTargetInput(flipFlop.Clock);
            return flipFlop;
        }

        private readonly List<LevelTriggeredDataFlipFlop> _flipFlops;
        private readonly InputWireHub _clockHub = new();
    }
}