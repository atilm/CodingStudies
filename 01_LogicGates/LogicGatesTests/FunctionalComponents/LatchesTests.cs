using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents.Latches;
using NUnit.Framework;

namespace LogicGatesTests.FunctionalComponents
{
    [TestFixture]
    public class LatchesTests
    {
        [Test]
        public void FlipFlopTest()
        {
            var flipFlop = new FlipFlop();

            flipFlop.Q.Voltage.Should().Be(Voltage.Off);
            flipFlop.QBar.Voltage.Should().Be(Voltage.On);

            flipFlop.InputB.Set(Voltage.On);
            flipFlop.InputB.Set(Voltage.Off);
            
            flipFlop.Q.Voltage.Should().Be(Voltage.On);
            flipFlop.QBar.Voltage.Should().Be(Voltage.Off);
            
            flipFlop.InputA.Set(Voltage.On);
            flipFlop.InputA.Set(Voltage.Off);
            
            flipFlop.Q.Voltage.Should().Be(Voltage.Off);
            flipFlop.QBar.Voltage.Should().Be(Voltage.On);
        }
    }
}