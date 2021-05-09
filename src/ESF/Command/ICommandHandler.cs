namespace ESF.Command
{
    public interface ICommandHandler<in TCommand> : IHandler where TCommand : ICommand
    {
        void Handle(TCommand cmd);
    }
}