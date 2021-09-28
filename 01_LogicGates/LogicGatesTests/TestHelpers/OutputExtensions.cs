using FluentAssertions;
using LogicGates.BasicComponents;

namespace LogicGatesTests.TestHelpers
{
    public static class OutputExtensions
    {
        public static void ShouldBe(this Output output, int expectedState)
        {
            var expectedVoltage = expectedState == 0 ? Voltage.Off : Voltage.On;
            output.Voltage.Should().Be(expectedVoltage);
        }
    }
}