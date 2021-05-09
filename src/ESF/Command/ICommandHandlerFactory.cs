namespace ESF.Command
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand;
    }
}