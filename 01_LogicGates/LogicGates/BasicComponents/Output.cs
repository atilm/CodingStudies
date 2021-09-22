using System.Collections.Generic;

namespace LogicGates.BasicComponents
{
    public class Output
    {
        public void Connect(Input input)
        {
            m_inputs.Add(input);
            input.Set(_mVoltage);
        }

        public void Set(Voltage voltage)
        {
            _mVoltage = voltage;

            foreach (var input in m_inputs)
                input.Set(_mVoltage);         
        }

        private readonly IList<Input> m_inputs = new List<Input>();
        private Voltage _mVoltage = Voltage.Off;
    }
}