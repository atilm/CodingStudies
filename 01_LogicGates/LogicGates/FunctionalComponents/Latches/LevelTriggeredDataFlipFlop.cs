using LogicGates.BasicComponents;
using LogicGates.LogicGates;

namespace LogicGates.FunctionalComponents.Latches
{
    public class LevelTriggeredDataFlipFlop : IFlipFlop
    {
        public LevelTriggeredDataFlipFlop()
        {
            Q = _flipFlop.Q;
            QBar = _flipFlop.QBar;
            Clock = _flipFlop.Clock;
            
            _hub.ConnectSourceInput(Data);
            _hub.ConnectTargetInput(_inverter.Input);
            _inverter.Output.Connect(_flipFlop.InputA);
            _hub.ConnectTargetInput(_flipFlop.InputB);
        }
        
        public Input Clock { get; }
        public Input Data { get; } = new();
        public Output Q { get; }
        public Output QBar { get; }

        private LevelTriggeredFlipFlop _flipFlop = new();
        private InputWireHub _hub = new();
        private Inverter _inverter = new();
    }
}