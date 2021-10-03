using System.Collections;
using System.Linq;
using System.Text;
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

        public static string ToBitString(this Voltage[] voltages)
        {
            var stringBuilder = new StringBuilder();
            return voltages
                .Reverse()
                .Aggregate(stringBuilder, (builder, voltage) => builder.Append(voltage == Voltage.Off ? "0" : "1"))
                .ToString();
        }
    }
}