using Christmas.Services;
using Christmas.ViewModel;
using Microsoft.Identity.Client;

namespace Christmas.View;

public partial class LandingPage : ContentPage
{
    private readonly AuthenticationService authenticationService;

    public LandingPage(AboutViewModel aboutViewModel, AuthenticationService authenticationService)
    {
        InitializeComponent();
        BindingContext = aboutViewModel;

        this.authenticationService = authenticationService;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (await authenticationService.SignInSilentAsync(Constants.Scopes).ConfigureAwait(false))
        {
            await Dispatcher.DispatchAsync(async () => await Shell.Current.GoToAsync("//Home"));
        }
        else
        {
            await Dispatcher.DispatchAsync(() =>
            {
                SplashBackground.BackgroundColor = Colors.Transparent;
                SplashImage.IsVisible = false;
                ContentLayout.IsVisible = true;
            });
        }
    }
    
    private async void SignInButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (await authenticationService.SignInAsync(Constants.Scopes).ConfigureAwait(false))
            {
                await Dispatcher.DispatchAsync(async () => await Shell.Current.GoToAsync("//Home"));
            }
            else
            {
                await DisplayErrorAlert("An unknown error occurred while signing in. Please try again.").ConfigureAwait(false);
            }
        }
        catch (MsalClientException)
        {
            await DisplayErrorAlert("You must login with your azyra.com email to continue.").ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await DisplayErrorAlert("An error occurred while signing in. Please try again.\n\n" + ex.Message).ConfigureAwait(false);
        }
    }
    
    private async Task DisplayErrorAlert(string message)
    {
        if (Dispatcher.IsDispatchRequired)
        {
            await Dispatcher.DispatchAsync(async () => await DisplayAlert("Error", message, "OK"));
        }
        else
        {
            await DisplayAlert("Error", message, "OK").ConfigureAwait(false);
        }
    }
}