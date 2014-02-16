using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Example.BusyAmbientContext
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private IContextStore<string> BusyContextStore { get; set; }

        public string Busy
        {
            get { return (this.BusyContextStore as IStoreReader<string>).Current; }
        }

        protected ViewModelBase()
        {
            this.BusyContextStore = new ContextStore<string>();
        }

        protected BusyContext CreateBusyContext(string message)
        {
            var context = new BusyContext(this.BusyContextStore, message,this.NotifyBusyChanged);
            return context;
        }

        private void NotifyBusyChanged()
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs("Busy"));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
