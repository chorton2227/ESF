using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF.Event
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<TEvent>> Resolve<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}
