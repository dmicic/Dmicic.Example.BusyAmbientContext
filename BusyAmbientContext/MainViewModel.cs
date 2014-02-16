using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dmicic.Example.BusyAmbientContext
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ComputeCommand { get; private set; }

        public MainViewModel()
        {
            this.ComputeCommand = new RelayCommand((p) => this.Compute(), (p) => true);
        }

        public async Task Compute()
        {
            var needMoreData = true;
            using (this.CreateBusyContext("Compute..."))
            {
                // Compute something
                await Task.Factory.StartNew(() => Thread.Sleep(1000));

                // Oh, we need additional data
                if (needMoreData)
                {
                    using (this.CreateBusyContext("Load required data..."))
                    {
                        // Load data
                        await Task.Factory.StartNew(() => Thread.Sleep(2000));
                    }
                }

                // Continue computation
                await Task.Factory.StartNew(() => Thread.Sleep(1000));
            }
        }
    }
}
