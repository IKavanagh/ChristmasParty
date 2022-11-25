using Android.App;
using Android.Content;
using Android.OS;
using Microsoft.Identity.Client;

namespace Christmas;

[Activity(Exported = true)]
[IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
    DataHost = "auth",
    DataScheme = $"msald1fb1775-22ea-4999-b72f-3964a42a8f4b"
)]
public class MsalActivity : BrowserTabActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set navigation bar color
        Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#4F74B8"));
    }
}
