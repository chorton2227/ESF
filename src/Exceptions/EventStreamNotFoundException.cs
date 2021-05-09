namespace ESF.Exceptions
{
    using ESF.Domain;
    using System;

    [Serializable]
    public class EventStreamNotFoundException : ESFException
    {
        public EventStreamNotFoundException(StreamIdentifier identifier)
            : base(string.Format("Event Stream Not Found: {0}", identifier.Value))
        {
        }
    }
}