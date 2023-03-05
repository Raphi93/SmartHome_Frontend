using dotnet_Maui.Models;
using dotnet_Maui.View;
using dotnet_Maui.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;

namespace dotnet_Maui;

public partial class MainPage : ContentPage
{
    private MainViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        viewModel = new MainViewModel();
        BindingContext = viewModel;
        NavigationPage.SetHasNavigationBar(this, false);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Update the BindingContext
        viewModel = new MainViewModel();
        BindingContext = viewModel;
        NavigationPage.SetHasNavigationBar(this, false);
    }
}

