using Christmas.ViewModel;

namespace Christmas.View;

public partial class MainPage : ContentPage
{
    public MainPage(EventsViewModel eventsViewModel)
    {
        InitializeComponent();
        BindingContext = eventsViewModel;

        eventsViewModel.GetEventsCommand.Execute(null);
    }
}