using LogicGates.BasicComponents;

namespace LogicGatesTests.TestHelpers
{
    public static class InputExtensions
    {
        public static void Set(this Input input, int boolean)
        {
            input.Set(boolean == 0 ? Voltage.Off : Voltage.On);
        }

        public static void SwitchOnOff(this Input input)
        {
            input.Set(Voltage.On);
            input.Set(Voltage.Off);
        }
    }
}