using LogicGates.BasicComponents;

namespace LogicGates.LogicGates
{
    public class NOrGate
    {
        public NOrGate()
        {
            Input1 = _orGate.Input1;
            Input2 = _orGate.Input2;

            _orGate.Output.Connect(_inverter.Input);
            Output = _inverter.Output;
        }
        
        public Input Input1 { get; }
        public Input Input2 { get; }
        public Output Output { get; }
        private readonly OrGate _orGate = new();
        private readonly Inverter _inverter = new();
    }
}