using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.LogicGates;
using NUnit.Framework;

namespace LogicGatesTests.LogicGates
{
    [TestFixture]
    public class NAndGateTests
    {
        [Test]
        [TestCase(Voltage.Off, Voltage.Off, LightBulb.BulbState.On)]
        [TestCase(Voltage.On, Voltage.Off, LightBulb.BulbState.On)]
        [TestCase(Voltage.Off, Voltage.On, LightBulb.BulbState.On)]
        [TestCase(Voltage.On, Voltage.On, LightBulb.BulbState.Off)]
        public void NAndGateTest(Voltage voltage1, Voltage voltage2, LightBulb.BulbState expectedBulbState)
        {
            var source1 = new VoltageSource(voltage1);
            var source2 = new VoltageSource(voltage2);
            var lightBulb = new LightBulb();
            var nAndGate = new NAndGate();

            source1.Output.Connect(nAndGate.Input1);
            source2.Output.Connect(nAndGate.Input2);
            nAndGate.Output.Connect(lightBulb.Input);

            lightBulb.State.Should().Be(expectedBulbState);
        }
    }
}