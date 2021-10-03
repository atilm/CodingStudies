using FluentAssertions;
using LogicGates.BasicComponents;
using LogicGates.FunctionalComponents.Latches;

namespace LogicGatesTests.TestHelpers
{
    public static class NBitLatchExtensions
    {
        public static void SetInputs(this NBitLatch latch, Voltage[] voltages)
        {
            for (var i = 0; i < voltages.Length; i++)
                latch.Input(i).Set(voltages[i]);
        }
    }
}