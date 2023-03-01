using dotnet_Maui.ViewModel;

namespace dotnet_Maui.View;

public partial class WetterView : ContentPage
{
    private WetterViewModel viewModel;

    public WetterView()
    {
        InitializeComponent();
        viewModel = new WetterViewModel();
        BindingContext = viewModel;
        NavigationPage.SetHasNavigationBar(this, false);
    }
}