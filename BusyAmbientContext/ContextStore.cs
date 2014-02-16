using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Example.BusyAmbientContext
{
    public class ContextStore<TData> : IContextStore<TData>
    {
        private Stack<AmbientContext<TData>> _Store = new Stack<AmbientContext<TData>>();

        public TData Current
        {
            get
            {
                if (_Store.Any())
                    return _Store.Peek().Data;
                return default(TData);
            }
        }

        public void Add(AmbientContext<TData> context)
        {
            this._Store.Push(context);
        }

        public void Remove()
        {
            this._Store.Pop();
        }
    }
}
