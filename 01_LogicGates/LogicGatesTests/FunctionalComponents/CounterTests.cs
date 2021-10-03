using System;
using System.Collections;
using LogicGates.FunctionalComponents.Counters;
using LogicGatesTests.TestHelpers;
using NUnit.Framework;

namespace LogicGatesTests.FunctionalComponents
{
    [TestFixture]
    public class CounterTests
    {
        [Test]
        public void NBitRippleCounterTest()
        {
            var counter = new NBitRippleCounter(4);

            for (byte i = 1; i < 16; i++)
            {
                var bitArray = new BitArray(new[] { i });
                Console.WriteLine(bitArray.ToVoltageArray().ToBitString());
                Console.WriteLine(counter.ToVoltageArray(4).ToBitString());
                Console.WriteLine();
                // counter.OutputsShouldBe(bitArray.ToVoltageArray());
                counter.Clock.Switch();
            }
        }
    }
}