namespace ESF.Event
{
    public interface IEventObserver
    {
        void Notify<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}