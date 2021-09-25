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
            var hub = new OutputWireHub();
            var sources = Enumerable.Range(0, 2).Select(_ => new VoltageSource(Voltage.Off)).ToList();
            var bulbs = Enumerable.Range(0, 2).Select(_ => new LightBulb()).ToList();

            foreach (var source in sources)
                hub.ConnectSourceOutput(source.Output);

            foreach (var bulbOutput in bulbs.Select(OutputToBulb))
                hub.ConnectTargetOutput(bulbOutput);

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
            var hub = new OutputWireHub();
            var bulb = new LightBulb();
            var source = new VoltageSource();

            hub.ConnectTargetOutput(OutputToBulb(bulb));
            bulb.ShouldBeOff();

            hub.ConnectSourceOutput(source.Output);
            bulb.ShouldBeOn();

            source.SwitchOff();
            bulb.ShouldBeOff();
        }

        [Test]
        public void WhenAnOutputIsAddedToAnActiveHubItsStateIsSet()
        {
            var hub = new OutputWireHub();
            var bulb = new LightBulb();
            var source = new VoltageSource();

            hub.ConnectSourceOutput(source.Output);
            hub.ConnectTargetOutput(OutputToBulb(bulb));
            bulb.ShouldBeOn();

            source.SwitchOff();
            bulb.ShouldBeOff();
        }
        
        private Output OutputToBulb(LightBulb bulb)
        {
            var proxyOutput = new Output();
            proxyOutput.Connect(bulb.Input);
            return proxyOutput;
        }
    }
}