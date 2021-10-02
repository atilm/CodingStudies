using LogicGates.BasicComponents;
using LogicGates.LogicGates;

namespace LogicGates.FunctionalComponents.Latches
{
    public class LevelTriggeredFlipFlop : IFlipFlop
    {
        public LevelTriggeredFlipFlop()
        {
            Q = _flipFlop.Q;
            QBar = _flipFlop.QBar;

            _andA.Output.Connect(_flipFlop.InputA);
            _andB.Output.Connect(_flipFlop.InputB);

            InputA = _andA.Input1;
            InputB = _andB.Input1;
            
            _hub.ConnectSourceInput(Clock);
            _hub.ConnectTargetInput(_andA.Input2);
            _hub.ConnectTargetInput(_andB.Input2);
        }
        
        public Input InputA { get; }
        public Input InputB { get; }
        public Input Clock { get; } = new();
        public Output Q { get; }
        public Output QBar { get; }

        private readonly FlipFlop _flipFlop = new();

        private readonly AndGate _andA = new();
        private readonly AndGate _andB = new();

        private readonly InputWireHub _hub = new();
    }
}