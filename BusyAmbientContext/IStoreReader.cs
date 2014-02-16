using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Example.BusyAmbientContext
{
    public interface IStoreReader<TData>
    {
        TData Current { get; }
    }
}
