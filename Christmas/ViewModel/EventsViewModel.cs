using Christmas.Model;
using Christmas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Christmas.ViewModel;
public partial class EventsViewModel : BaseViewModel
{
    public ObservableCollection<Event> Events { get; } = new();

    readonly EventService eventsService;
    
    public EventsViewModel(EventService eventsService)
    {
        Title = "Schedule";
        this.eventsService = eventsService;
    }

    [RelayCommand]
    private async void GetMonkeys()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;

            var events = eventsService.GetEvents();
            if (events.Count != 0)
            {
                Events.Clear();
            }

            foreach (var @event in events)
            {
                Events.Add(@event);
            }
        }
        catch (Exception ex)
        {
            // TODO: Add better error handling
            Debug.WriteLine($"Unable to get events: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
