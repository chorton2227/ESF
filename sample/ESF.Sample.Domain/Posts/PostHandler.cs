namespace ESF.Sample.Domain.Posts
{
    using ESF.Command;
    using ESF.Persistence;
    using ESF.Sample.Messages.Posts.Commands;

    public class PostHandler :
        ICommandHandler<CreateNewPost>
    {
        private readonly IRepository _repo;

        public PostHandler(IRepository repo)
        {
            _repo = repo;
        }

        public void Handle(CreateNewPost cmd)
        {
            _repo.Save(Post.Create(cmd.PostId));
        }
    }
}