using Christmas.Model;
using Christmas.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Christmas.ViewModel;
public partial class EventsViewModel : BaseViewModel
{    
    public ObservableCollection<Event> Events { get; } = new();

    public ObservableCollection<Event> ThursdayEvents { get; } = new();

    public ObservableCollection<Event> FridayEvents { get; } = new();

    [ObservableProperty]
    private EventDay day = DateTime.Now.DayOfWeek is DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday ? EventDay.Thursday : EventDay.Friday;

    [ObservableProperty]
    private string[] days = Enum.GetNames(typeof(EventDay));

    [ObservableProperty]
    private string subTitle;

    private readonly EventService eventsService;
    
    public EventsViewModel(EventService eventsService)
    {
        Title = "Christmas Schedule";
        SubTitle = "2022";
        
        this.eventsService = eventsService;
    }

    [RelayCommand]
    private async void GetEvents()
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
                if (@event.Day == EventDay.Thursday)
                {
                    ThursdayEvents.Add(@event);
                }
                else if (@event.Day == EventDay.Friday)
                {
                    FridayEvents.Add(@event);
                }
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
