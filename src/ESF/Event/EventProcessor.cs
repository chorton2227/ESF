namespace ESF.Event
{
    using ESF.Persistence;
    using System;

    public class EventProcessor : IEventObserver
    {
        private readonly IEventDispatcher _dispatcher;

        private readonly Action _unsubscribe;

        public EventProcessor(IEventStore store, IEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _unsubscribe = store.Subscribe(this);
        }

        public void Notify<TEvent>(TEvent evt) where TEvent : IEvent
        {
            _dispatcher.Send(evt);
        }
    }
}