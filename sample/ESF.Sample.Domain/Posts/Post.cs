namespace ESF.Sample.Domain.Posts
{
    using ESF.Domain;
    using ESF.Sample.Messages.Posts.Events;
    using System;

    public class Post : Aggregate
    {
        protected override void RegisterAppliers()
        {
            RegisterApplier<PostCreated>(Apply);
        }

        public Post()
        {
        }

        private Post(Guid postId)
        {
            ApplyChanges(new PostCreated { PostId = postId });
        }

        public static Post Create(Guid postId)
        {
            return new Post(postId);
        }

        public void Apply(PostCreated evt)
        {
            Id = evt.PostId;
        }
    }
}