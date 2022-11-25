using Foundation;
using UIKit;

namespace Christmas;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        PlatformConfiguration.Instance.RedirectUri = "msauth.com.companyname.mauiappbasic://auth";

        return base.FinishedLaunching(application, launchOptions);
    }
}
