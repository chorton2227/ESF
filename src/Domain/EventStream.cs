namespace ESF.Domain
{
    using ESF.Exceptions;
    using System;
    using System.Collections.Generic;

    public abstract class EventStream
    {
        private readonly List<IEvent> _newEvents;

        private readonly Dictionary<Type, Action<IEvent>> _appliers;

        public string Name { get { return GetType().Name; } }

        protected Guid Id { get; set; }

        public StreamIdentifier StreamIdentifier
        {
            get
            {
                return new StreamIdentifier(Name, Id);
            }
        }

        protected EventStream()
        {
            _newEvents = new List<IEvent>();
            _appliers = new Dictionary<Type, Action<IEvent>>();
            RegisterAppliers();
        }

        protected abstract void RegisterAppliers();

        protected void RegisterApplier<TEvent>(Action<TEvent> applier) where TEvent : IEvent
        {
            _appliers.Add(typeof(TEvent), (x) => applier((TEvent)x));
        }

        protected void ApplyChanges(IEvent evt)
        {
            Apply(evt);
            _newEvents.Add(evt);
        }

        private void Apply(IEvent evt)
        {
            var evtType = evt.GetType();

            if (!_appliers.ContainsKey(evtType))
            {
                throw new NoEventApplyMethodRegisteredException(evt, this);
            }

            _appliers[evtType](evt);
        }

        public void Load(IEnumerable<IEvent> events)
        {
            foreach (var evt in events)
            {
                Apply(evt);
            }
        }

        public IEnumerable<IEvent> GetUncommitedChanges()
        {
            return _newEvents.AsReadOnly();
        }

        public void Commit()
        {
            _newEvents.Clear();
        }
    }
}