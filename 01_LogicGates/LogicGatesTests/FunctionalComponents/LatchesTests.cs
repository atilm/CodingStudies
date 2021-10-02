using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents.Latches;
using LogicGatesTests.TestHelpers;
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
            flipFlop.QShouldBe(Voltage.Off);

            flipFlop.InputB.SwitchOnOff();
            flipFlop.QShouldBe(Voltage.On);
            
            flipFlop.InputA.SwitchOnOff();
            flipFlop.QShouldBe(Voltage.Off);
        }

        [Test]
        public void LevelTriggeredFlipFlopTest()
        {
            var flipFlop = new LevelTriggeredFlipFlop();
            flipFlop.QShouldBe(Voltage.Off);
            
            flipFlop.InputB.SwitchOnOff();
            flipFlop.QShouldBe(Voltage.Off);

            flipFlop.Clock.Set(Voltage.On);
            
            flipFlop.InputB.SwitchOnOff();
            flipFlop.QShouldBe(Voltage.On);
            
            flipFlop.Clock.Set(Voltage.Off);
            
            flipFlop.InputA.SwitchOnOff();
            flipFlop.QShouldBe(Voltage.On);
            
            flipFlop.Clock.Set(Voltage.On);
            
            flipFlop.InputA.SwitchOnOff();
            flipFlop.QShouldBe(Voltage.Off);
        }
    }
}