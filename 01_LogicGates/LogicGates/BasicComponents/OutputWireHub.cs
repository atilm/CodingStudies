namespace LogicGates.BasicComponents
{
    public class OutputWireHub : WireHubBase<Output>
    {
        public void ConnectTargetOutput(Output output)
        {
            TargetInterfaces.Add(output);
            UpdateTargets();
        }

        public void ConnectSourceOutput(Output output)
        {
            SourceInterfaces.Add(output);
            var proxyInput = new Input();
            output.Connect(proxyInput);
            proxyInput.RegisterAction(_ => UpdateTargets());
        }
    }
}