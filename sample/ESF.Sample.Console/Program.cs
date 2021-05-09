namespace ESF.Sample.Console
{
    using ESF.Sample.Bootstrap;
    using ESF.Sample.Messages.Posts.Commands;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var app = Bootstrapper.Bootstrap();

            app.Send(new CreateNewPost { PostId = Guid.NewGuid() });
        }
    }
}
