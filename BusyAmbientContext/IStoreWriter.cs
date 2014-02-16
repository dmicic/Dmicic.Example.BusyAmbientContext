using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Example.BusyAmbientContext
{
    public interface IStoreWriter<TData>
    {
        void Add(AmbientContext<TData> context);
        void Remove();
    }
}
