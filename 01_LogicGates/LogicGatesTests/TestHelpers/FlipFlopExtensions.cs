using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents.Latches;

namespace LogicGatesTests.TestHelpers
{
    public static class FlipFlopExtensions
    {
        public static void QShouldBe(this IFlipFlop flipFlop, Voltage voltage)
        {
            flipFlop.Q.Voltage.Should().Be(voltage);
            flipFlop.QBar.Voltage.Should().NotBe(flipFlop.Q.Voltage);
        }
    }
}