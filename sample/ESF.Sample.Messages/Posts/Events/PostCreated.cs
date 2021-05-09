namespace ESF.Sample.Messages.Posts.Events
{
    using System;

    public class PostCreated : IEvent
    {
        public Guid PostId { get; set; }
    }
}