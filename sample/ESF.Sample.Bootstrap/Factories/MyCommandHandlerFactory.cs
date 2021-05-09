namespace ESF.Sample.Bootstrap.Factories
{
    using ESF.Command;
    using ESF.Persistence;
    using ESF.Sample.Domain.Posts;
    using ESF.Sample.Messages.Posts.Commands;

    public class MyCommandHandlerFactory : CommandHandlerFactory
    {
        public MyCommandHandlerFactory(IEventStore eventStore) : base(eventStore)
        {
        }

        protected override void RegisterHandlerFactories()
        {
            RegisterHandlerFactory(
                () => new PostHandler(CreateRepositiory()),
                typeof(CreateNewPost));
        }
    }
}