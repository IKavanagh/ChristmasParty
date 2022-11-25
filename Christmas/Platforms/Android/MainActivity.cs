using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Identity.Client;

namespace Christmas;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set navigation bar color
        Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#4F74B8"));

        // Configure platform specific redirect URI and parent window
        PlatformConfiguration.Instance.RedirectUri = $"msal{Constants.ClientId}://auth";
        PlatformConfiguration.Instance.ParentWindow = this;
    }

    /// <summary>
    /// Override OnActivityResult to pass the result to the MSAL library
    /// </summary>
    /// <param name="requestCode">The integer request code originally supplied to startActivityForResult().</param>
    /// <param name="resultCode">The integer result code returned by the child activity through its setResult().</param>
    /// <param name="data">An Intent, which can return result data to the caller.</param>
    protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        // Pass the activity result to the MSAL library
        AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
    }
}
