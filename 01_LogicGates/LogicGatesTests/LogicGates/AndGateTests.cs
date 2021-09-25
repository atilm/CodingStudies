using LogicGates.BasicComponents;
using LogicGates.LogicGates;
using LogicGatesTests.BasicComponents;
using NUnit.Framework;

namespace LogicGatesTests.LogicGates
{
    [TestFixture]
    public class AndGateTests
    {
        [Test]
        public void AndGateTest()
        {
            var voltage1 = new VoltageSource(Voltage.Off);
            var voltage2 = new VoltageSource(Voltage.Off);
            var lightBulb = new LightBulb();
            var andGate = new AndGate();

            voltage1.Output.Connect(andGate.Input1);
            voltage2.Output.Connect(andGate.Input2);
            andGate.Output.Connect(lightBulb.Input);
            
            lightBulb.ShouldBeOff();

            voltage1.SwitchOn();
            lightBulb.ShouldBeOff();
            voltage1.SwitchOff();
            
            voltage2.SwitchOn();
            lightBulb.ShouldBeOff();
            
            voltage1.SwitchOn();
            lightBulb.ShouldBeOn();
            
            voltage2.SwitchOff();
            lightBulb.ShouldBeOff();
        }
    }
}