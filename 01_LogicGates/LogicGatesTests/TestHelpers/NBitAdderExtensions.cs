using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents.Adders;

namespace LogicGatesTests.TestHelpers
{
    public enum AdderInput
    {
        A,
        B
    }
    
    public static class NBitAdderExtensions
    {
        public static void SetInput(this NBitAdder adder, AdderInput inputSelector, Voltage[] bits)
        {
            for (var i = 0; i < bits.Length; i++)
                adder.SetInput(inputSelector, i, bits[i]);
        }

        public static void SetInput(this NBitAdder adder, AdderInput inputSelector, int index, Voltage value)
        {
            var input = inputSelector is AdderInput.A
                ? adder.InputA(index)
                : adder.InputB(index);

            input.Set(value);
        }

        public static void OutputsShouldBe(this NBitAdder adder, Voltage[] bits)
        {
            for (var i = 0; i < bits.Length; i++)
                adder.Output(i).Voltage.Should().Be(bits[i]);
        }
    }
}