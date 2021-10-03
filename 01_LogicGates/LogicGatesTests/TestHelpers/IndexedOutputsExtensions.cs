using System.Linq;
using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents;

namespace LogicGatesTests.TestHelpers
{
    public static class IndexedOutputsExtensions
    {
        public static void OutputsShouldBe(this IIndexedOutputs component, Voltage[] bits)
        {
            for (var i = 0; i < bits.Length; i++)
                component.Output(i).Voltage.Should().Be(bits[i]);
        }

        public static Voltage[] ToVoltageArray(this IIndexedOutputs component, int bits)
        {
            return Enumerable
                .Range(0, bits)
                .Select(i => component.Output(i).Voltage)
                .ToArray();
        }
    }
}