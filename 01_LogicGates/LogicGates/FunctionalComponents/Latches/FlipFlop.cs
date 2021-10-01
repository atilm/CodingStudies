using LogicGates.BasicComponents;
using LogicGates.LogicGates;

namespace LogicGates.FunctionalComponents.Latches
{
    public class FlipFlop
    {
        public FlipFlop()
        {
            InputA = _norA.Input1;
            InputB = _norB.Input1;

            _norB.Output.Connect(_norA.Input2);
            _norA.Output.Connect(_norB.Input2);
            
            Q = _norA.Output;
            QBar = _norB.Output;
        }
        
        public Input InputA { get; }
        public Input InputB { get; }
        public Output Q { get; }
        public Output QBar { get; }

        private NOrGate _norA { get; } = new();
        private NOrGate _norB { get; } = new();
        private OutputWireHub _hubA { get; } = new();
        private OutputWireHub _hubB { get; } = new();
    }
}
