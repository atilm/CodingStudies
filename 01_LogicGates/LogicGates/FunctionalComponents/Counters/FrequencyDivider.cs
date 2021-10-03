using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents.Latches;

namespace LogicGates.FunctionalComponents.Counters
{
    public class FrequencyDivider
    {
        public FrequencyDivider()
        {
            Input = _flipFlop.Clock;
            Q = _flipFlop.Q;
            QBar = _flipFlop.QBar;

            _flipFlop.QBar.Connect(_flipFlop.Data);
        }
        
        public Input Input { get; }
        public Output Q { get; }
        
        public Output QBar { get; }

        private readonly EdgeTriggeredDataFlipFlop _flipFlop = new();
    }
}