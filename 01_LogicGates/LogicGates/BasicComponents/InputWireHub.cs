namespace LogicGates.BasicComponents
{
    public class InputWireHub : WireHubBase<Input>
    {
        public void ConnectSourceInput(Input input)
        {
            SourceInterfaces.Add(input);
            input.RegisterAction(_ => UpdateTargets());
        }

        public void ConnectTargetInput(Input input)
        {
            TargetInterfaces.Add(input);
            UpdateTargets();
        }
    }
}