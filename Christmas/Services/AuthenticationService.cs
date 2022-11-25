using Microsoft.Identity.Client;

namespace Christmas.Services;
public class AuthenticationService
{
    private HttpClient HttpClient { get; init; } = new HttpClient();

    private IPublicClientApplication IdentityClient { get; init; }

    private bool UseEmbedded { get; set; } = false;

    public AuthenticationService() : this(true) { }

    public AuthenticationService(bool useEmbedded)
    {
        UseEmbedded = useEmbedded;
        
        IdentityClient = PublicClientApplicationBuilder
            .Create(Constants.ClientId)
            .WithRedirectUri(PlatformConfiguration.Instance.RedirectUri)
            .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
            .Build();
    }

    public async Task<bool> SignInAsync(string[] scopes)
    {
        AuthenticationResult result;
        try
        {
            result = await AcquireTokenSilentAsync(scopes).ConfigureAwait(false);
        }
        catch (MsalUiRequiredException)
        {
            result = await AcquireTokenInteractiveAsync(scopes).ConfigureAwait(false);
        }

        return await CheckTokenAsync(result).ConfigureAwait(false);
    }

    public async Task<bool> SignInSilentAsync(string[] scopes)
    {
        AuthenticationResult result;
        try
        {
            result = await AcquireTokenSilentAsync(scopes).ConfigureAwait(false);
        }
        catch (MsalUiRequiredException)
        {
            return false;
        }

        return await CheckTokenAsync(result).ConfigureAwait(false);
    }

    public async Task SignOutAsync()
    {
        var accounts = await IdentityClient.GetAccountsAsync().ConfigureAwait(false);
        foreach (var account in accounts)
        {
            await IdentityClient.RemoveAsync(account).ConfigureAwait(false);
        }
    }

    private async Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes)
    {
        var accounts = await IdentityClient.GetAccountsAsync().ConfigureAwait(false);
        return await IdentityClient.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync().ConfigureAwait(false);
    }
    
    private async Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes)
    {
        var builder = IdentityClient.AcquireTokenInteractive(scopes);
        if (UseEmbedded)
        {
            builder.WithUseEmbeddedWebView(true);
        }
        else
        {
            SystemWebViewOptions systemWebViewOptions = new();
#if IOS
            // Hide the privacy prompt in iOS
            systemWebViewOptions.iOSHidePrivacyPrompt = true;
#endif
            builder.WithSystemWebViewOptions(systemWebViewOptions);
        }

        return await builder
            .WithTenantId(Constants.TenantId)
            .WithAuthority($"https://login.microsoftonline.com/{Constants.TenantId}")
            .WithParentActivityOrWindow(PlatformConfiguration.Instance.ParentWindow)
            .ExecuteAsync().ConfigureAwait(false);
    }

    private async Task<bool> CheckTokenAsync(AuthenticationResult authResult)
    {
        HttpRequestMessage message = new(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me");
        message.Headers.Add("Authorization", authResult.CreateAuthorizationHeader());

        var response = await HttpClient.SendAsync(message).ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }
}
