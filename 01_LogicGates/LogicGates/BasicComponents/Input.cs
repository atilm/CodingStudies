using System;
using System.Collections.Generic;

namespace LogicGates.BasicComponents
{
    public class Input : IVoltageInterface
    {
        public void RegisterAction(Action<Voltage> action)
        {
            _actions.Add(action);
            action(Voltage);
        }

        public void UnregisterAction(Action<Voltage> action)
        {
            _actions.Remove(action);
        }

        public void Set(Voltage voltage)
        {
            var previous = Voltage;
            Voltage = voltage;

            if (Voltage == previous)
                return;

            foreach (var action in _actions)
                action(Voltage);
        }
        
        public Voltage Voltage { get; private set; } = Voltage.Off;

        private readonly IList<Action<Voltage>> _actions = new List<Action<Voltage>>();
    }
}