using FluentAssertions;
using LogicGates.BasicComponents;

namespace LogicGatesTests
{
    public static class LightBulbExtensions
    {
        public static void ShouldBeOn(this LightBulb bulb)
        {
            bulb.State.Should().Be(LightBulb.BulbState.On);
        }
        
        public static void ShouldBeOff(this LightBulb bulb)
        {
            bulb.State.Should().Be(LightBulb.BulbState.Off);
        }
    }
}