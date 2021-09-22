namespace LogicGates.BasicComponents
{
    public class Relay
    {
        public Relay()
        {
            VoltageInput = Switch.Input;
            InvertedOutput = Switch.OutputA;
            Output = Switch.OutputB;

            Input.RegisterAction(TriggerSwitch);
        }

        public Input Input { get; } = new();
        public Input VoltageInput { get; }
        public Output Output { get; }
        public Output InvertedOutput { get; }

        private TwoWaySwitch Switch { get; } = new();

        private void TriggerSwitch(Voltage voltage)
        {
            if (voltage == Voltage.On)
                Switch.SwitchToOutputB();
            else
                Switch.SwitchToOutputA();
        }
    }
}