using System.Linq;
using LogicGates.BasicComponents;
using LogicGatesTests.TestHelpers;
using NUnit.Framework;

namespace LogicGatesTests.BasicComponents
{
    [TestFixture]
    public class InputWireHubTests
    {
        [Test]
        public void AWireHubImplementsALogicalOr()
        {
            var hub = new InputWireHub();
            var sources = Enumerable.Range(0, 2).Select(_ => new VoltageSource(Voltage.Off)).ToList();
            var bulbs = Enumerable.Range(0, 2).Select(_ => new LightBulb()).ToList();

            foreach (var sourceInput in sources.Select(InputFromSource))
                hub.ConnectSourceInput(sourceInput);

            foreach (var bulb in bulbs)
                hub.ConnectTargetInput(bulb.Input);

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
        public void WhenAnSourceInputIsAddedToAnActiveHubItsStateIsSet()
        {
            var hub = new InputWireHub();
            var bulb = new LightBulb();
            var source = new VoltageSource();

            hub.ConnectTargetInput(bulb.Input);
            bulb.ShouldBeOff();

            hub.ConnectSourceInput(InputFromSource(source));
            bulb.ShouldBeOn();

            source.SwitchOff();
            bulb.ShouldBeOff();
        }

        [Test]
        public void WhenATargetInputIsAddedToAnActiveHubItsStateIsSet()
        {
            var hub = new InputWireHub();
            var bulb = new LightBulb();
            var source = new VoltageSource();

            hub.ConnectSourceInput(InputFromSource(source));
            hub.ConnectTargetInput(bulb.Input);
            bulb.ShouldBeOn();

            source.SwitchOff();
            bulb.ShouldBeOff();
        }

        private Input InputFromSource(VoltageSource source)
        {
            var proxyInput = new Input();
            source.Output.Connect(proxyInput);
            return proxyInput;
        }
    }
}