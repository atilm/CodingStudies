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
            var voltage1 = new VoltageSource();
            var voltage2 = new VoltageSource();
            var lightBulb = new LightBulb();
            var orGate = new AndGate();
            
            voltage1.SwitchOff();
            voltage2.SwitchOff();

            voltage1.Output.Connect(orGate.Input1);
            voltage2.Output.Connect(orGate.Input2);
            orGate.Output.Connect(lightBulb.Input);
            
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