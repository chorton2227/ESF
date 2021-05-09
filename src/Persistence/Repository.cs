namespace ESF.Persistence
{
    using ESF.Domain;
    using System;
    using System.Collections.Generic;

    public class Repository : IRepository
    {
        private readonly IEventStore _eventStore;

        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public T GetById<T>(Guid id) where T : EventStream, new()
        {
            var eventStream = new T();
            var streamId = new StreamIdentifier(eventStream.Name, id);
            var events = _eventStore.GetByStreamId(streamId);
            eventStream.Load(events);
            return eventStream;
        }

        public void Save(params EventStream[] eventStreams)
        {
            var newEvents = new List<EventStoreStream>();
            foreach (var eventStream in eventStreams)
            {
                newEvents.Add(new EventStoreStream(eventStream.StreamIdentifier, eventStream.GetUncommitedChanges()));
            }

            _eventStore.Save(newEvents);

            foreach (var eventStream in eventStreams)
            {
                eventStream.Commit();
            }
        }
    }
}