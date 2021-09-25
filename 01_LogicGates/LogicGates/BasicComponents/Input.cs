using System;
using System.Collections.Generic;

namespace LogicGates.BasicComponents
{
    public class Input
    {
        public void RegisterAction(Action<Voltage> action)
        {
            m_actions.Add(action);
            action(Voltage);
        }

        public void UnregisterAction(Action<Voltage> action)
        {
            m_actions.Remove(action);
        }

        public void Set(Voltage voltage)
        {
            var previous = Voltage;
            Voltage = voltage;

            if (Voltage == previous)
                return;

            foreach (var action in m_actions)
                action(Voltage);
        }
        
        public Voltage Voltage { get; private set; } = Voltage.Off;

        private readonly IList<Action<Voltage>> m_actions = new List<Action<Voltage>>();
    }
}