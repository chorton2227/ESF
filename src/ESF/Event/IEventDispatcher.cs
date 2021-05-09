namespace ESF.Event
{
    public interface IEventDispatcher
    {
        void Send<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}