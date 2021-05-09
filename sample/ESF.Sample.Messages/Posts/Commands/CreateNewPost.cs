namespace ESF.Sample.Messages.Posts.Commands
{
    using System;

    public class CreateNewPost : ICommand
    {
        public Guid PostId { get; set; }
    }
}