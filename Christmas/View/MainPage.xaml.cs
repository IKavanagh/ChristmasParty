using Christmas.ViewModel;

namespace Christmas.View;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(EventsViewModel eventsViewModel)
    {
        InitializeComponent();
        BindingContext = eventsViewModel;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}