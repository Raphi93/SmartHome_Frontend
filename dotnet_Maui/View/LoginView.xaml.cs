using dotnet_Maui.ViewModel;

namespace dotnet_Maui.View;

public partial class LoginView : ContentPage
{
    private LoginViewModel viewModel;
	public LoginView()
	{
        viewModel = new LoginViewModel();
        BindingContext = viewModel;
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}