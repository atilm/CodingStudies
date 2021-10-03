using LogicGates.BasicComponents;
using LogicGates.LogicGates;

namespace LogicGates.FunctionalComponents.Latches
{
    public class EdgeTriggeredDataFlipFlop : IFlipFlop
    {
        public EdgeTriggeredDataFlipFlop()
        {
            _clockHub.ConnectSourceInput(Clock);
            _clockHub.ConnectTargetInput(_clockInverter.Input);

            _clockInverter.Output.Connect(_flipFlop1.Clock);
            Data = _flipFlop1.Data;
            
            _flipFlop1.Q.Connect(_flipFlop2.InputB);
            _flipFlop1.QBar.Connect(_flipFlop2.InputA);
            _clockHub.ConnectTargetInput(_flipFlop2.Clock);

            Q = _flipFlop2.Q;
            QBar = _flipFlop2.QBar;
        }

        public Input Clock { get; } = new();
        public Input Data { get; }
        public Output Q { get; }
        public Output QBar { get; }

        private readonly InputWireHub _clockHub = new();
        private readonly Inverter _clockInverter = new();
        private readonly LevelTriggeredDataFlipFlop _flipFlop1 = new();
        private readonly LevelTriggeredFlipFlop _flipFlop2 = new();
    }
}