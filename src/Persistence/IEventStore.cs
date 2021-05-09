namespace ESF.Persistence
{
    using ESF.Domain;
    using ESF.Event;
    using System;
    using System.Collections.Generic;

    public interface IEventStore
    {
        IEnumerable<IEvent> GetByStreamId(StreamIdentifier streamId);

        void Save(List<EventStoreStream> newEvents);

        Action Subscribe(IEventObserver observer);
    }
}