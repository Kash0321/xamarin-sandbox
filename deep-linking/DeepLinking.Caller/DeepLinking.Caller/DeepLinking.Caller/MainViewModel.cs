using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeepLinking.Caller
{
    public class MainViewModel : ViewModel
    {
        public Command GotoPage1Command { get; set; }
        public Command GotoPage2Command { get; set; }

        public MainViewModel()
        {
            GotoPage1Command = new Command(() => GotoPage1());
            GotoPage2Command = new Command(() => GotoPage2());
        }

        private void GotoPage1()
        {
            MessagingCenter.Send(this, "GotoPage1", "Page 1");
        }

        private void GotoPage2()
        {
            MessagingCenter.Send(this, "GotoPage2", "Page 1");
        }
    }
}
