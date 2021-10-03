using System.Collections;
using System.Linq;
using LogicGates.BasicComponents;

namespace LogicGatesTests.TestHelpers
{
    public static class VoltageHelper
    {
        public static Voltage[] ToVoltageArray(this string s)
        {
            return s
                .Reverse()
                .Select(c => c == '0' ? Voltage.Off : Voltage.On)
                .ToArray();
        }
        
        public static Voltage[] ToVoltageArray(this BitArray bits)
        {
            return bits
                .Cast<bool>()
                .Select(b => b ? Voltage.On : Voltage.Off)
                .ToArray();
        }
    }
}