using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.LogicGates;
using NUnit.Framework;

namespace LogicGatesTests.LogicGates
{
    [TestFixture]
    public class AndGateTests
    {
        [Test]
        [TestCase(Voltage.Off, Voltage.Off, LightBulb.BulbState.Off)]
        [TestCase(Voltage.On, Voltage.Off, LightBulb.BulbState.Off)]
        [TestCase(Voltage.Off, Voltage.On, LightBulb.BulbState.Off)]
        [TestCase(Voltage.On, Voltage.On, LightBulb.BulbState.On)]
        public void AndGateTest(Voltage voltage1, Voltage voltage2, LightBulb.BulbState expectedBulbState)
        {
            var source1 = new VoltageSource(voltage1);
            var source2 = new VoltageSource(voltage2);
            var lightBulb = new LightBulb();
            var orGate = new AndGate();

            source1.Output.Connect(orGate.Input1);
            source2.Output.Connect(orGate.Input2);
            orGate.Output.Connect(lightBulb.Input);

            lightBulb.State.Should().Be(expectedBulbState);
        }
    }
}