using LogicGates.BasicComponents;
using LogicGates.LogicGates;

namespace LogicGates.FunctionalComponents.Adders
{
    public class HalfAdder
    {
        public HalfAdder()
        {
            var hubA = new InputWireHub();
            hubA.ConnectSourceInput(InputA);
            hubA.ConnectTargetInput(_xor.Input1);
            hubA.ConnectTargetInput(_and.Input1);

            var hubB = new InputWireHub();
            hubB.ConnectSourceInput(InputB);
            hubB.ConnectTargetInput(_xor.Input2);
            hubB.ConnectTargetInput(_and.Input2);
            
            Sum = _xor.Output;
            Carry = _and.Output;
        }

        public Input InputA { get; } = new();
        public Input InputB { get; } = new();
        public Output Sum { get; }
        public Output Carry { get; }

        private readonly XOrGate _xor = new();
        private readonly AndGate _and = new();
    }
}