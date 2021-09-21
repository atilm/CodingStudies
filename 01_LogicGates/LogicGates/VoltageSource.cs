using System;

namespace LogicGates
{
    public class VoltageSource
    {
        public VoltageSource()
        {
            SwitchOn();
        }

        public void SwitchOn()
        {
            Output.Set(Voltage.On);
        }

        public void SwitchOff()
        {
            Output.Set(Voltage.Off);
        }

        public Output Output { get; } = new Output();
    }
}
