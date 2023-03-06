using dotnet_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Maui.ViewModel
{
    public class LogOutViewModel
    {
        private Command _cmdNein { get; set; }
        private Command _cmdJa { get; set; }
        private Command _cmdBack { get; set; }

        public LogOutViewModel()
        {
            _cmdBack = new Command(ExecuteBack);
            _cmdNein = new Command(ExecuteBack);
            _cmdJa = new Command(ExecuteJa);
        }

        private async void ExecuteJa()
        {
            Configuration config = ConfigManager.LoadConfig();
            config.ApiKey = "";
            ConfigManager.SaveConfig(config);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void ExecuteBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public Command CmdNein
        {
            get { return _cmdNein; }
            set { _cmdNein = value; }
        }

        public Command CmdJa
        {
            get { return _cmdJa; }
            set { _cmdJa = value; }
        }

        public Command CmdBack
        {
            get { return _cmdBack; }
            set { _cmdBack = value; }
        }
    }
}
