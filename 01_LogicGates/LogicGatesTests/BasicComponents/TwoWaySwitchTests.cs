using LogicGates.BasicComponents;
using LogicGatesTests.TestHelpers;
using NUnit.Framework;

namespace LogicGatesTests.BasicComponents
{
    [TestFixture]
    public class TwoWaySwitchTests
    {
        [Test]
        public void InitialStateIsOutputA()
        {
            var system = new SystemUnderTest();

            system.BulbA.ShouldBeOn();
            system.BulbB.ShouldBeOff();
        }
        
        [Test]
        public void SwitchFromAToA()
        {
            var system = new SystemUnderTest();

            system.Switch.SwitchToOutputA();
            
            system.BulbA.ShouldBeOn();
            system.BulbB.ShouldBeOff();
        }
        
        [Test]
        public void SwitchFromAToB()
        {
            var system = new SystemUnderTest();

            system.Switch.SwitchToOutputB();
            
            system.BulbA.ShouldBeOff();
            system.BulbB.ShouldBeOn();
        }
        
        [Test]
        public void SwitchFromBToA()
        {
            var system = new SystemUnderTest();
            system.Switch.SwitchToOutputB();
            
            system.Switch.SwitchToOutputA();
            
            system.BulbA.ShouldBeOn();
            system.BulbB.ShouldBeOff();
        }

        [Test]
        public void SwitchBackAndForthAndSwitchVoltageOffAndOn()
        {
            var system = new SystemUnderTest();
            
            system.Switch.SwitchToOutputB();
            system.Switch.SwitchToOutputA();
            
            system.Voltage.SwitchOff();
            
            system.BulbA.ShouldBeOff();
            system.BulbB.ShouldBeOff();

            system.Voltage.SwitchOn();
            
            system.BulbA.ShouldBeOn();
            system.BulbB.ShouldBeOff();

            system.Switch.SwitchToOutputB();
            
            system.Voltage.SwitchOff();
            
            system.BulbA.ShouldBeOff();
            system.BulbB.ShouldBeOff();

            system.Voltage.SwitchOn();
            
            system.BulbA.ShouldBeOff();
            system.BulbB.ShouldBeOn();
        }

        private class SystemUnderTest
        {
            public VoltageSource Voltage { get; } = new();
            public TwoWaySwitch Switch { get; } = new();
            public LightBulb BulbA { get; } = new();
            public LightBulb BulbB { get; } = new();

            public SystemUnderTest()
            {
                Voltage.Output.Connect(Switch.Input);
                Switch.OutputA.Connect(BulbA.Input);
                Switch.OutputB.Connect(BulbB.Input);
            }
        }
    }
}