﻿namespace ESF.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerFactory _factory;

        public CommandDispatcher(ICommandHandlerFactory factory)
        {
            _factory = factory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _factory.Resolve<TCommand>();
            handler.Handle(command);
        }
    }
}