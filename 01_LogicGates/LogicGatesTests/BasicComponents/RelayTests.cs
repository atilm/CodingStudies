using LogicGates.BasicComponents;
using LogicGatesTests.TestHelpers;
using NUnit.Framework;

namespace LogicGatesTests.BasicComponents
{
    [TestFixture]
    public class RelayTests
    {
        [Test]
        public void SwitchOnAndOff()
        {
            var system = new TestSystem();

            system.OutputBulb.ShouldBeOff();
            system.InvertedOutputBulb.ShouldBeOn();

            system.ControlVoltage.SwitchOn();

            system.OutputBulb.ShouldBeOn();
            system.InvertedOutputBulb.ShouldBeOff();

            system.ControlVoltage.SwitchOff();

            system.OutputBulb.ShouldBeOff();
            system.InvertedOutputBulb.ShouldBeOn();
        }

        [Test]
        public void SwitchSupplyVoltageOnAndOff()
        {
            var system = new TestSystem();

            system.OutputBulb.ShouldBeOff();
            system.InvertedOutputBulb.ShouldBeOn();

            system.Voltage.SwitchOff();

            system.OutputBulb.ShouldBeOff();
            system.InvertedOutputBulb.ShouldBeOff();

            system.Voltage.SwitchOn();

            system.OutputBulb.ShouldBeOff();
            system.InvertedOutputBulb.ShouldBeOn();
        }

        private class TestSystem
        {
            public TestSystem()
            {
                Voltage.Output.Connect(Relay.VoltageInput);
                ControlVoltage.SwitchOff();
                ControlVoltage.Output.Connect(Relay.Input);
                Relay.Output.Connect(OutputBulb.Input);
                Relay.InvertedOutput.Connect(InvertedOutputBulb.Input);
            }

            public VoltageSource Voltage { get; } = new();
            public VoltageSource ControlVoltage { get; } = new();
            private Relay Relay { get; } = new();
            public LightBulb OutputBulb { get; } = new();
            public LightBulb InvertedOutputBulb { get; } = new();
        }
    }
}