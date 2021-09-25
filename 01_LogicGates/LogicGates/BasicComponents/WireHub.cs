using System.Collections.Generic;
using System.Linq;

namespace LogicGates.BasicComponents
{
    public class WireHub
    {
        public void ConnectTargetOutput(Output output)
        {
            _targetOutputs.Add(output);
            UpdateOutputs();
        }

        public void ConnectSourceOutput(Output output)
        {
            var proxyInput = new Input();
            proxyInput.RegisterAction(UpdateOutputs);
            output.Connect(proxyInput);
            
            _sourceOutputs.Add(output);
            UpdateOutputs();
        }

        private void UpdateOutputs(Voltage _)
        {
            UpdateOutputs();
        }
        
        private void UpdateOutputs()
        {
            var voltage = DetermineSetVoltage();
            
            foreach (var output in _targetOutputs)
                output.Set(voltage);
        }

        private Voltage DetermineSetVoltage()
        {
            return _sourceOutputs.Any(o => o.Voltage == Voltage.On)
                ? Voltage.On
                : Voltage.Off;
        }
        
        private readonly List<Output> _sourceOutputs = new();
        private readonly List<Output> _targetOutputs = new();
    }
}