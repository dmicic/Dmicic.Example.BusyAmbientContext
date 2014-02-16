using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Example.BusyAmbientContext
{
    public class BusyContext : AmbientContext<string>
    {
        public BusyContext(IStoreWriter<string> store, string busyMessage, Action onContextChange = null)
            : base(store, busyMessage, onContextChange)
        { }
    }
}
