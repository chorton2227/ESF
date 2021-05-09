namespace ESF.Sample.Bootstrap.Factories
{
    using ESF.Command;
    using ESF.Event;
    using ESF.Persistence;

    public class MyEventHandlerFactory : EventHandlerFactory
    {
        public MyEventHandlerFactory(IEventStore eventStore, ICommandDispatcher dispatcher) :
            base(eventStore, dispatcher)
        {
        }

        protected override void RegisterHandlerFactories(IEventStore eventStore, ICommandDispatcher dispatcher)
        {
        }
    }
}