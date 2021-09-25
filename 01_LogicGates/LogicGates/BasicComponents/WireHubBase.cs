using System.Collections.Generic;
using System.Linq;

namespace LogicGates.BasicComponents
{
    public class WireHubBase<T> where T : IVoltageInterface
    {
        protected readonly List<T> SourceInterfaces = new();
        protected readonly List<T> TargetInterfaces = new();

        protected void UpdateTargets()
        {
            var voltage = DetermineSetVoltage();
            
            foreach (var targetInterface in TargetInterfaces)
                targetInterface.Set(voltage);
        }

        private Voltage DetermineSetVoltage()
        {
            return SourceInterfaces.Any(o => o.Voltage == Voltage.On)
                ? Voltage.On
                : Voltage.Off;
        }
    }
}