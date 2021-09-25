using LogicGates.BasicComponents;

namespace LogicGates.LogicGates
{
    public class XOrGate
    {
        public XOrGate()
        {
            Output = _andGate.Output;

            _orGate.Output.Connect(_andGate.Input1);
            _nAndGate.Output.Connect(_andGate.Input2);

            var wireHub1 = CreateWireHub(Input1);
            wireHub1.ConnectTargetInput(_orGate.Input1);
            wireHub1.ConnectTargetInput(_nAndGate.Input1);

            var wireHub2 = CreateWireHub(Input2);
            wireHub2.ConnectTargetInput(_orGate.Input2);
            wireHub2.ConnectTargetInput(_nAndGate.Input2);
        }

        private InputWireHub CreateWireHub(Input sourceInput)
        {
            var wireHub1 = new InputWireHub();
            wireHub1.ConnectSourceInput(sourceInput);
            return wireHub1;
        }

        public Input Input1 { get; } = new();
        public Input Input2 { get; } = new();
        public Output Output { get; }

        private readonly OrGate _orGate = new();
        private readonly NAndGate _nAndGate = new();
        private readonly AndGate _andGate = new();
    }
}