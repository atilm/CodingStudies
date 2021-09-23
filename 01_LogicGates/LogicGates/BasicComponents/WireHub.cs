using System.Collections.Generic;
using System.Linq;

namespace LogicGates.BasicComponents
{
    public class WireHub
    {
        public void ConnectInput(Input input)
        {
            m_inputs.Add(input);
            UpdateInputs();
        }

        public void ConnectOutput(Output output)
        {
            var proxyInput = new Input();
            proxyInput.RegisterAction(UpdateInputs);
            output.Connect(proxyInput);
            
            m_outputs.Add(output);
            UpdateInputs();
        }

        private void UpdateInputs(Voltage _)
        {
            UpdateInputs();
        }
        
        private void UpdateInputs()
        {
            var voltage = DetermineSetVoltage();
            
            foreach (var input in m_inputs)
                input.Set(voltage);
        }

        private Voltage DetermineSetVoltage()
        {
            return m_outputs.Any(o => o.Voltage == Voltage.On)
                ? Voltage.On
                : Voltage.Off;
        }
        
        private List<Output> m_outputs = new();
        private List<Input> m_inputs = new();
    }
}