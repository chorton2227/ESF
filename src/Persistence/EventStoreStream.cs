namespace ESF.Persistence
{
    using ESF.Domain;
    using System.Collections.Generic;
    using System.Linq;

    public class EventStoreStream
    {
        public string Id { get; private set; }

        public List<IEvent> Events { get; private set; }

        public EventStoreStream(StreamIdentifier streamId, IEnumerable<IEvent> events)
        {
            Id = streamId.Value;
            Events = events.ToList();
        }
    }
}