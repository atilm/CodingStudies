using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents;

namespace LogicGatesTests.TestHelpers
{
    public static class IndexedOutputsExtensions
    {
        public static void OutputsShouldBe(this IIndexedOutputs adder, Voltage[] bits)
        {
            for (var i = 0; i < bits.Length; i++)
                adder.Output(i).Voltage.Should().Be(bits[i]);
        }
    }
}