using Christmas.ViewModel;

namespace Christmas.View;

public partial class AboutPage : ContentPage
{
    public AboutPage(AboutViewModel aboutViewModel)
    {
        InitializeComponent();
        BindingContext = aboutViewModel;
    }
}