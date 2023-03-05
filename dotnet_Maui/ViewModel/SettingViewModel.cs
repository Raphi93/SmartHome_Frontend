using dotnet_Maui.Models;

namespace dotnet_Maui.ViewModel
{
    class SettingViewModel : ViewModelBase
    {
        private readonly Command _cmdBack;
        private Command _cmdSave;
        private Configuration _setting = new Configuration();


        public SettingViewModel()
        {
            _cmdBack = new Command(ExecuteBack);
            _cmdSave = new Command(ExecuteSave);
            ShowContent();
        }

        private void ShowContent()
        {
            Configuration conf = ConfigManager.LoadConfig();
            Config = conf;
        }

        private async void ExecuteBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void ExecuteSave()
        {
            Configuration conf = ConfigManager.LoadConfig();
            conf.Url = Config.Url;
            conf.WeatherUrl = Config.WeatherUrl;
            conf.UserUrl = Config.UserUrl;
            conf.HeizungUrl = Config.HeizungUrl;
            ConfigManager.SaveConfig(conf);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public Command CmdSave => _cmdSave;

        public Configuration Config
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
        }

        public Command CmdBack => _cmdBack;

    }
}
