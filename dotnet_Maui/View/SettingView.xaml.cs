using dotnet_Maui.ViewModel;

namespace dotnet_Maui.View;

public partial class SettingView : ContentPage
{
    SettingViewModel setting;
    public SettingView()
	{
        setting = new SettingViewModel();
        BindingContext = setting;
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}