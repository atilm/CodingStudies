using LogicGates.BasicComponents;
using LogicGates.LogicGates;

namespace LogicGates.FunctionalComponents.Adders
{
    public class FullAdder
    {
        public FullAdder()
        {
            InputA = _firstHalf.InputA;
            InputB = _firstHalf.InputB;

            CarryIn = _secondHalf.InputA;
            _firstHalf.Sum.Connect(_secondHalf.InputB);

            _firstHalf.Carry.Connect(_carryOr.Input1);
            _secondHalf.Carry.Connect(_carryOr.Input2);
            
            Sum = _secondHalf.Sum;
            Carry = _carryOr.Output;
        }
        
        public Input InputA { get; }
        public Input InputB { get; }
        public Input CarryIn { get; }
        public Output Sum { get; }
        public Output Carry { get; }

        public readonly HalfAdder _firstHalf = new();
        public readonly HalfAdder _secondHalf = new();
        public readonly OrGate _carryOr = new();
    }
}