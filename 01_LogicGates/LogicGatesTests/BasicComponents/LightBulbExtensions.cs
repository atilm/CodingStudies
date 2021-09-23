using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LogicGates.BasicComponents;

namespace LogicGatesTests.BasicComponents
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

        public static void ShouldAllBeOn(this IEnumerable<LightBulb> bulbs)
        {
            bulbs.Select(b => b.State).Should().AllBeEquivalentTo(LightBulb.BulbState.On);
        }
        
        public static void ShouldAllBeOff(this IEnumerable<LightBulb> bulbs)
        {
            bulbs.Select(b => b.State).Should().AllBeEquivalentTo(LightBulb.BulbState.Off);
        }
    }
}