using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dmicic.Example.BusyAmbientContext
{
    public abstract class AmbientContext<TData> : IDisposable
    {
        private IStoreWriter<TData> _Store;

        private Action _OnDispose;

        public TData Data { get; private set; }

        public AmbientContext(IStoreWriter<TData> store, TData data, Action onContextChange = null)
        {
            this.Data = data;
            _Store = store;
            this._OnDispose = onContextChange;

            _Store.Add(this);
            this.NotifyChange();
        }

        private void NotifyChange()
        {
            if (this._OnDispose != null)
                this._OnDispose();
        }


        public virtual void Dispose()
        {
            _Store.Remove();
            this.NotifyChange();
        }
    }
}
