using LogicGates.BasicComponents;

namespace LogicGates.LogicGates
{
    public class OrGate
    {
        public OrGate()
        {
            _source.Output.Connect(_relay1.VoltageInput);
            _source.Output.Connect(_relay2.VoltageInput);
            
            Input1 = _relay1.Input;
            Input2 = _relay2.Input;

            _hub.ConnectSourceOutput(_relay1.Output);
            _hub.ConnectSourceOutput(_relay2.Output);
            _hub.ConnectTargetOutput(Output);
        }

        public Input Input1 { get; }
        public Input Input2 { get; }
        public Output Output { get; } = new();
        
        private readonly Relay _relay1 = new();
        private readonly Relay _relay2 = new();
        private readonly OutputWireHub _hub = new();
        private readonly VoltageSource _source = new();
    }
}