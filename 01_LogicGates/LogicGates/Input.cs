using System;
using System.Collections.Generic;

namespace LogicGates
{
    public class Input
    {
        public void RegisterAction(Action<Voltage> action)
        {
            m_actions.Add(action);
            action(m_voltage);
        }

        public void Set(Voltage voltage)
        {
            var previous = m_voltage;
            m_voltage = voltage;

            if (m_voltage == previous)
                return;

            foreach (var action in m_actions)
                action(m_voltage);
        }

        private IList<Action<Voltage>> m_actions = new List<Action<Voltage>>();
        private Voltage m_voltage = Voltage.Off;
    }
}