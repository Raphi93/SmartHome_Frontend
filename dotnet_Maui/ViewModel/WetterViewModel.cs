using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Maui.ViewModel
{
    class WetterViewModel
    {
        private Command _cmdBack { get; set; }


        public WetterViewModel()
        {
            _cmdBack = new Command(ExecuteBack, CanExecuteBack);
        }

        private async void ExecuteBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private bool CanExecuteBack()
        {
            return true;

        }

        public Command CmdBack
        {
            get { return _cmdBack; }
            set { _cmdBack = value; }
        }
    }
}
