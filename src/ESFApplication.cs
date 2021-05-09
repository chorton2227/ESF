namespace ESF
{
    using ESF.Command;

    public class ESFApplication
    {
        private readonly CommandDispatcher _commandDispatcher;

        public ESFApplication(CommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public void Send<TCommand>(TCommand cmd) where TCommand : ICommand
        {
            _commandDispatcher.Send(cmd);
        }
    }
}