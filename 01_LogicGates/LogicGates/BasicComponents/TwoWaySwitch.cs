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
            if (m_state == State.B)
                return;
            
            OutputA.Set(Voltage.Off);
            Input.UnregisterAction(OutputA.Set);
            Input.RegisterAction(OutputB.Set);
            m_state = State.B;
        }

        public void SwitchToOutputA()
        {
            if (m_state == State.A)
                return;
            
            OutputB.Set(Voltage.Off);
            Input.UnregisterAction(OutputB.Set);
            Input.RegisterAction(OutputA.Set);

            m_state = State.A;
        }
        
        public Output OutputA { get; } = new();
        public Output OutputB { get; } = new();
        public Input Input { get; } = new();

        private State m_state = State.Undefined;

        private enum State
        {
            Undefined,
            A,
            B
        }
    }
}