using Christmas.Model;
using Christmas.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Christmas.ViewModel;
public partial class EventsViewModel : BaseViewModel
{
    public string[] Days => Enum.GetNames(typeof(EventDay));

    public ObservableCollection<Event> Events => Day switch
    {
        EventDay.Thursday => ThursdayEvents,
        EventDay.Friday => FridayEvents,
        _ => throw new IndexOutOfRangeException("Day must be either EventDay.Thursday or EventDay.Friday")
    };

    public ObservableCollection<Event> ThursdayEvents { get; } = new();

    public ObservableCollection<Event> FridayEvents { get; } = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Events))]
    private EventDay day = DateTime.Now.DayOfWeek is DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday ? EventDay.Thursday : EventDay.Friday;

    [ObservableProperty]
    private string subTitle;

    private readonly EventService eventsService;
    
    public EventsViewModel(EventService eventsService)
    {
        Title = "Conference Schedule";
        SubTitle = "2022";
        
        this.eventsService = eventsService;
    }

    [RelayCommand]
    private async void SetDay(string arg)
    {
        IsBusy = true;

        await Task.Delay(1); // Hack to make activity indicator display
        
        if (Enum.TryParse<EventDay>(arg, out var day))
        {
            Day = day;
        }

        IsBusy = false;
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
            IsBusy = !IsRefreshing;

            await Task.Delay(1); // Hack to make activity indicator display until GetEvents is async

            var events = eventsService.GetEvents();
            if (events.Count != 0)
            {
                ThursdayEvents.Clear();
                FridayEvents.Clear();
            }

            foreach (var @event in events)
            {
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
            IsRefreshing = false;
        }
    }
}
