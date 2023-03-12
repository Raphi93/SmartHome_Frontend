using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using Xamarin.Android.Net;

namespace dotnet_Maui;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
  
}
