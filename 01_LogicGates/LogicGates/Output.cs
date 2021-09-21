using System;
using System.Collections.Generic;

namespace LogicGates
{
    public class Output
    {
        public void Connect(Input input)
        {
            m_inputs.Add(input);
            input.Set(m_voltage);
        }

        public void Set(Voltage voltage)
        {
            m_voltage = voltage;

            foreach (var input in m_inputs)
                input.Set(m_voltage);         
        }

        private IList<Input> m_inputs = new List<Input>();
        private Voltage m_voltage = Voltage.Off;
    }
}