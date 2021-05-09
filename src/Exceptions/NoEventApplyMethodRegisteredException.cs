namespace ESF.Exceptions
{
    using ESF.Domain;
    using System;

    [Serializable]
    public class NoEventApplyMethodRegisteredException : ESFException
    {
        public NoEventApplyMethodRegisteredException(IEvent evt, EventStream eventStream)
            : base(string.Format("No Event Applier Registered for {0} on {1}", evt.GetType().Name, eventStream.Name))
        {
        }
    }
}