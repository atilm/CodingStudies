using FluentAssertions;
using LogicGates.BasicComponents;
using NUnit.Framework;

namespace LogicGatesTests.BasicComponents
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SwitchingALightBulbOnAndOffViaTheVoltageSource()
        {
            var source = new VoltageSource();
            var lightBulb = new LightBulb();
            source.Output.Connect(lightBulb.Input);

            lightBulb.State.Should().Be(LightBulb.BulbState.On);

            source.SwitchOff();
            lightBulb.State.Should().Be(LightBulb.BulbState.Off);

            source.SwitchOn();
            lightBulb.State.Should().Be(LightBulb.BulbState.On);
        }
    }
}