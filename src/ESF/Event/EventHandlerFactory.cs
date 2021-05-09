namespace ESF.Event
{
    using ESF.Command;
    using ESF.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class EventHandlerFactory : IEventHandlerFactory
    {
        private readonly IEventStore _eventStore;

        private readonly ICommandDispatcher _dispatcher;

        private readonly Dictionary<Type, List<Func<IHandler>>> _handlerFactories = new Dictionary<Type, List<Func<IHandler>>>();

        public EventHandlerFactory(IEventStore eventStore, ICommandDispatcher dispatcher)
        {
            RegisterHandlerFactories(eventStore, dispatcher);
        }

        protected IEventStore GetEventStore()
        {
            return _eventStore;
        }

        protected ICommandDispatcher GetDispatcher()
        {
            return _dispatcher;
        }

        protected abstract void RegisterHandlerFactories(IEventStore eventStore, ICommandDispatcher dispatcher);

        protected virtual IRepository CreateRepositiory()
        {
            return new Repository(_eventStore);
        }

        protected void RegisterHandlerFactory(Func<IHandler> handler, params Type[] types)
        {
            foreach (var type in types)
            {
                if (!_handlerFactories.ContainsKey(type))
                {
                    _handlerFactories.Add(type, new List<Func<IHandler>> { handler });
                }
                else
                {
                    _handlerFactories[type].Add(handler);
                }
            }
        }

        public IEnumerable<IEventHandler<TEvent>> Resolve<TEvent>(TEvent evt) where TEvent : IEvent
        {
            var evtType = evt.GetType();
            if (_handlerFactories.ContainsKey(evtType))
            {
                var factories = _handlerFactories[evtType];
                return factories.Select(h => (IEventHandler<TEvent>)h());
            }

            return new List<IEventHandler<TEvent>>();
        }
    }
}
