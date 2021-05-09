namespace ESF.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class ESFException : Exception
    {
        public ESFException()
        {
        }

        public ESFException(string message) : base(message)
        {
        }

        public ESFException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ESFException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}