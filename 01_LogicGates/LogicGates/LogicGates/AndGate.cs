using LogicGates.BasicComponents;

namespace LogicGates.LogicGates
{
    public class AndGate
    {
        public AndGate()
        {
            Voltage.Output.Connect(Relay1.VoltageInput);
            Input1 = Relay1.Input;
            Relay1.Output.Connect(Relay2.VoltageInput);
            
            Input2 = Relay2.Input;
            Output = Relay2.Output;
        }

        public Input Input1 { get; }
        public Input Input2 { get; }
        public Output Output { get; }

        private VoltageSource Voltage { get; } = new();
        private Relay Relay1 { get; } = new();
        private Relay Relay2 { get; } = new();
    }
}