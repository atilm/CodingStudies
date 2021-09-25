using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.LogicGates;
using NUnit.Framework;

namespace LogicGatesTests.LogicGates
{
    [TestFixture]
    public class InverterTests
    {
        [Test]
        [TestCase(Voltage.Off, LightBulb.BulbState.On)]
        [TestCase(Voltage.On, LightBulb.BulbState.Off)]
        public void InverterTest(Voltage inputVoltage, LightBulb.BulbState expectedState)
        {
            var source = new VoltageSource(inputVoltage);
            var inverter = new Inverter();
            var bulb = new LightBulb();

            source.Output.Connect(inverter.Input);
            inverter.Output.Connect(bulb.Input);

            bulb.State.Should().Be(expectedState);
        }
    }
}