namespace ESF.Event
{
    public interface IEventHandler<in TEvent> : IHandler where TEvent : IEvent
    {
        void Handle(TEvent evt);
    }
}