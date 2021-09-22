namespace LogicGates.BasicComponents
{
    public class TwoWaySwitch
    {
        public TwoWaySwitch()
        {
            SwitchToOutputA();
        }
        
        public void SwitchToOutputB()
        {
            OutputA.Set(Voltage.Off);
            Input.UnregisterAction(OutputA.Set);
            Input.RegisterAction(OutputB.Set);
        }

        public void SwitchToOutputA()
        {
            OutputB.Set(Voltage.Off);
            Input.UnregisterAction(OutputB.Set);
            Input.RegisterAction(OutputA.Set);
        }
        
        
        
        public Output OutputA { get; } = new();
        public Output OutputB { get; } = new();
        public Input Input { get; } = new();
    }
}