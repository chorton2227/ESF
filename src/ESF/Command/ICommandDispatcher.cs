namespace ESF.Command
{
    public interface ICommandDispatcher
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}