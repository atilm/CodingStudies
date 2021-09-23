using System.Linq;
using LogicGates.BasicComponents;
using NUnit.Framework;

namespace LogicGatesTests.BasicComponents
{
    [TestFixture]
    public class WireHubTests
    {
        [Test]
        public void AWireHubImplementsALogicalOr()
        {
            var hub = new WireHub();
            var sources = Enumerable.Range(0, 2).Select(_ => new VoltageSource(Voltage.Off)).ToList();
            var bulbs = Enumerable.Range(0, 2).Select(_ => new LightBulb()).ToList();

            foreach (var source in sources)
                hub.ConnectOutput(source.Output);

            foreach (var bulb in bulbs)
                hub.ConnectInput(bulb.Input);

            bulbs.ShouldAllBeOff();

            sources[0].SwitchOn();
            bulbs.ShouldAllBeOn();

            sources[1].SwitchOn();
            bulbs.ShouldAllBeOn();

            sources[0].SwitchOff();
            bulbs.ShouldAllBeOn();

            sources[1].SwitchOff();
            bulbs.ShouldAllBeOff();
        }

        [Test]
        public void WhenAnInputIsAddedToAnActiveHubItsStateIsSet()
        {
            var hub = new WireHub();
            var bulb = new LightBulb();
            var source = new VoltageSource();

            hub.ConnectInput(bulb.Input);
            bulb.ShouldBeOff();

            hub.ConnectOutput(source.Output);
            bulb.ShouldBeOn();

            source.SwitchOff();
            bulb.ShouldBeOff();
        }

        [Test]
        public void WhenAnOutputIsAddedToAnActiveHubItsStateIsSet()
        {
            var hub = new WireHub();
            var bulb = new LightBulb();
            var source = new VoltageSource();

            hub.ConnectOutput(source.Output);
            hub.ConnectInput(bulb.Input);
            bulb.ShouldBeOn();

            source.SwitchOff();
            bulb.ShouldBeOff();
        }
    }
}