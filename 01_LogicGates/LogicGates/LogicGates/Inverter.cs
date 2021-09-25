using LogicGates.BasicComponents;

namespace LogicGates.LogicGates
{
    public class Inverter
    {
        public Inverter()
        {
            _source.Output.Connect(_relay.VoltageInput);

            Input = _relay.Input;
            Output = _relay.InvertedOutput;
        }
        
        public Input Input { get; }
        public Output Output { get; }

        private readonly Relay _relay = new();
        private readonly VoltageSource _source = new();
    }
}