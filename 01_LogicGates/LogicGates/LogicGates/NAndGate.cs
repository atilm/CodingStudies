using LogicGates.BasicComponents;

namespace LogicGates.LogicGates
{
    public class NAndGate
    {
        public NAndGate()
        {
            Input1 = _andGate.Input1;
            Input2 = _andGate.Input2;

            _andGate.Output.Connect(_inverter.Input);
            Output = _inverter.Output;
        }
        
        public Input Input1 { get; }
        public Input Input2 { get; }
        public Output Output { get; }
        private readonly AndGate _andGate = new();
        private readonly Inverter _inverter = new();
    }
}