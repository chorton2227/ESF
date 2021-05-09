namespace ESF.Domain
{
    using System;

    public class StreamIdentifier
    {
        public string Value { get; private set; }

        public StreamIdentifier(string name, Guid id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Value = string.Format("{0}-{1}", name, id.ToString());
        }
    }
}