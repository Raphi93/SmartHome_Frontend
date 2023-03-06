using dotnet_Maui.ViewModel;

namespace dotnet_Maui.View;

public partial class LogOutView : ContentPage
{
	LogOutViewModel viewModel;
	public LogOutView()
	{
		viewModel= new LogOutViewModel();
        BindingContext = viewModel;
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}