using System.Linq;
using LogicGates.BasicComponents;

namespace LogicGatesTests.TestHelpers
{
    public static class StringExtensions
    {
        public static Voltage[] ToVoltageArray(this string s)
        {
            return s
                .Reverse()
                .Select(c => c == '0' ? Voltage.Off : Voltage.On)
                .ToArray();
        }
    }
}