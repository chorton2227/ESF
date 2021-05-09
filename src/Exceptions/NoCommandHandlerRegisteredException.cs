namespace ESF.Exceptions
{
    using System;

    [Serializable]
    public class NoCommandHandlerRegisteredException : ESFException
    {
        public NoCommandHandlerRegisteredException(Type command)
            : base(string.Format("No command Handler Registered for {0}", command.Name))
        {
        }
    }
}