namespace ESF.Command
{
    using ESF.Exceptions;
    using ESF.Persistence;
    using System;
    using System.Collections.Generic;

    public abstract class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IEventStore _eventStore;

        private readonly Dictionary<Type, Func<IHandler>> _handlerFactories = new Dictionary<Type, Func<IHandler>>();

        public CommandHandlerFactory(IEventStore eventStore)
        {
            _eventStore = eventStore;
            RegisterHandlerFactories();
        }

        protected IEventStore GetEventStore()
        {
            return _eventStore;
        }

        protected abstract void RegisterHandlerFactories();

        protected virtual IRepository CreateRepositiory()
        {
            return new Repository(_eventStore);
        }

        protected void RegisterHandlerFactory(Func<IHandler> handler, params Type[] types)
        {
            foreach (var type in types)
            {
                _handlerFactories.Add(type, handler);
            }
        }

        public ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand
        {
            if (_handlerFactories.ContainsKey(typeof(TCommand)))
            {
                if (_handlerFactories[typeof(TCommand)]() is ICommandHandler<TCommand> handler)
                {
                    return handler;
                }
            }

            throw new NoCommandHandlerRegisteredException(typeof(TCommand));
        }
    }
}