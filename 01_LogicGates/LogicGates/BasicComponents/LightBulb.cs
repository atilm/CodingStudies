namespace LogicGates.BasicComponents
{
    public class LightBulb
    {
        public LightBulb()
        {
            Input.RegisterAction(SetBulbState);
        }
        
        public enum BulbState
        {
            On,
            Off
        }

        public Input Input { get; } = new Input();

        public BulbState State { get; private set; } = BulbState.Off;

        private void SetBulbState(Voltage voltage)
        {
            State = voltage == Voltage.On
                    ? BulbState.On
                    : BulbState.Off;
        }
    }
}