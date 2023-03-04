using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Dotnet_Maui_Frontend;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        ServicePointManager.ServerCertificateValidationCallback += OnServerCertificateValidationCallback;

    }

    private bool OnServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Trust any certificate
        return true;
    }
}

