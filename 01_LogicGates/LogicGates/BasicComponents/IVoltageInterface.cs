namespace LogicGates.BasicComponents
{
    public interface IVoltageInterface
    {
        Voltage Voltage { get; }
        void Set(Voltage voltage);
    }
}