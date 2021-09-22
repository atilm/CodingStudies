using System;
using System.Collections.Generic;

namespace LogicGates.BasicComponents
{
    public class Input
    {
        public void RegisterAction(Action<Voltage> action)
        {
            m_actions.Add(action);
            action(_mVoltage);
        }

        public void UnregisterAction(Action<Voltage> action)
        {
            m_actions.Remove(action);
        }

        public void Set(Voltage voltage)
        {
            var previous = _mVoltage;
            _mVoltage = voltage;

            if (_mVoltage == previous)
                return;

            foreach (var action in m_actions)
                action(_mVoltage);
        }

        private readonly IList<Action<Voltage>> m_actions = new List<Action<Voltage>>();
        private Voltage _mVoltage = Voltage.Off;
    }
}