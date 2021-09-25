using System.Collections.Generic;
using System.Linq;

namespace LogicGates.BasicComponents
{
    public class InputWireHub
    {
        public void ConnectSourceInput(Input input)
        {
            _sourceInputs.Add(input);
            input.RegisterAction(_ => UpdateInputs());
        }

        public void ConnectTargetInput(Input input)
        {
            _targetInputs.Add(input);
            UpdateInputs();
        }

        private void UpdateInputs()
        {
            var voltage = DetermineSetVoltage();

            foreach (var input in _targetInputs)
                input.Set(voltage);
        }
        
        private Voltage DetermineSetVoltage()
        {
            return _sourceInputs.Any(o => o.Voltage == Voltage.On)
                ? Voltage.On
                : Voltage.Off;
        }

        private readonly List<Input> _sourceInputs = new();
        private readonly List<Input> _targetInputs = new();
    }
}