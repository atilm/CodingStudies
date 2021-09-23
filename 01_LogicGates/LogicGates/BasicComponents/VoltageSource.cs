namespace LogicGates.BasicComponents
{
    public class VoltageSource
    {
        public VoltageSource(Voltage initialState = Voltage.On)
        {
            Output.Set(initialState);
        }

        public void SwitchOn()
        {
            Output.Set(Voltage.On);
        }

        public void SwitchOff()
        {
            Output.Set(Voltage.Off);
        }

        public Output Output { get; } = new();
    }
}
