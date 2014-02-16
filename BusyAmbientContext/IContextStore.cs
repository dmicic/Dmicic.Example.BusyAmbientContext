using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Example.BusyAmbientContext
{
    public interface IContextStore<TData> : IStoreReader<TData>, IStoreWriter<TData>
    { }
}
