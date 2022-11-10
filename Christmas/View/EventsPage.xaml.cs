using Christmas.ViewModel;

namespace Christmas.View;

public partial class EventsPage : ContentPage
{
    public EventsPage(EventsViewModel eventsViewModel)
    {
        InitializeComponent();
        BindingContext = eventsViewModel;

        eventsViewModel.GetEventsCommand.Execute(null);
    }
}