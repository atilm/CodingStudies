using System.Collections.Generic;

namespace LogicGates.BasicComponents
{
    public class Output : IVoltageInterface
    {
        public void Connect(Input input)
        {
            _inputs.Add(input);
            input.Set(Voltage);
        }

        public void Set(Voltage voltage)
        {
            Voltage = voltage;

            foreach (var input in _inputs)
                input.Set(Voltage);         
        }
        
        public Voltage Voltage { get; private set; } = Voltage.Off;

        private readonly IList<Input> _inputs = new List<Input>();
    }
}