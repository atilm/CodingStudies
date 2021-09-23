using System.Collections.Generic;

namespace LogicGates.BasicComponents
{
    public class Output
    {
        public void Connect(Input input)
        {
            m_inputs.Add(input);
            input.Set(Voltage);
        }

        public void Set(Voltage voltage)
        {
            Voltage = voltage;

            foreach (var input in m_inputs)
                input.Set(Voltage);         
        }
        
        public Voltage Voltage { get; private set; } = Voltage.Off;

        private readonly IList<Input> m_inputs = new List<Input>();
    }
}