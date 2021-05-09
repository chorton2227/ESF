namespace ESF.Sample.Bootstrap
{
    using ESF.Command;
    using ESF.Event;
    using ESF.Infrastructure;
    using ESF.Sample.Bootstrap.Factories;

    public class Bootstrapper
    {
        public static ESFApplication Bootstrap()
        {
            var eventStore = new InMemoryEventStore();

            var commandHandlerFactory = new MyCommandHandlerFactory(eventStore);
            var commandDispatcher = new CommandDispatcher(commandHandlerFactory);

            var eventHandlerFactory = new MyEventHandlerFactory(eventStore, commandDispatcher);
            var eventDispatcher = new EventDispatcher(eventHandlerFactory);
            _ = new EventProcessor(eventStore, eventDispatcher);

            return new ESFApplication(commandDispatcher);
        }
    }
}