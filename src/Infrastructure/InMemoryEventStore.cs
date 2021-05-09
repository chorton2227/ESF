namespace ESF.Infrastructure
{
    using ESF.Domain;
    using ESF.Event;
    using ESF.Exceptions;
    using ESF.Persistence;
    using System;
    using System.Collections.Generic;

    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<string, List<IEvent>> _store = new Dictionary<string, List<IEvent>>();

        private readonly List<IEventObserver> _eventObservers = new List<IEventObserver>();

        public IEnumerable<IEvent> GetByStreamId(StreamIdentifier streamId)
        {
            if (_store.ContainsKey(streamId.Value))
            {
                return _store[streamId.Value].AsReadOnly();
            }

            throw new EventStreamNotFoundException(streamId);
        }

        public void Save(List<EventStoreStream> newEvents)
        {
            foreach (var eventStoreStream in newEvents)
            {
                PersistEvents(eventStoreStream);
                DispatchEvents(eventStoreStream.Events);
            }
        }

        private void PersistEvents(EventStoreStream eventStoreStream)
        {
            if (_store.ContainsKey(eventStoreStream.Id))
            {
                _store[eventStoreStream.Id].AddRange(eventStoreStream.Events);
            }
            else
            {
                _store.Add(eventStoreStream.Id, eventStoreStream.Events);
            }
        }

        private void DispatchEvents(IEnumerable<IEvent> newEvents)
        {
            foreach (var evt in newEvents)
            {
                NotifySubscribers(evt);
            }
        }

        private void NotifySubscribers(IEvent evt)
        {
            dynamic typeAwareEvent = evt; // this cast is required to pass the correct Type to the Notify Method. Otherwise IEvent is used as the Type
            foreach (var observer in _eventObservers)
            {
                observer.Notify(typeAwareEvent);
            }
        }

        public Action Subscribe(IEventObserver observer)
        {
            _eventObservers.Add(observer);
            return () => Unsubscribe(observer);
        }

        private void Unsubscribe(IEventObserver observer)
        {
            _eventObservers.Remove(observer);
        }
    }
}