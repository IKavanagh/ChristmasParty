using Christmas.Model;

namespace Christmas.Services;
public class EventService
{
    private readonly List<Event> eventsList = new();
    
    public List<Event> GetEvents()
    {
        if (eventsList?.Count > 0)
        {
            return eventsList;
        }

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Arrive at Herbert Park Hotel",
            Details = "Time for people to arrive at the Herbert Park Hotel",
            Start = new DateTime(2022, 12, 8, 9, 0, 0),
            End = new DateTime(2022, 12, 8, 14, 0, 0),
            Day = EventDay.Thursday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Introduction and Opening Session",
            Details = "Introduction to the conference and a description of the events planned",
            Start = new DateTime(2022, 12, 8, 14, 0, 0),
            End = new DateTime(2022, 12, 8, 14, 15, 0),
            Day = EventDay.Thursday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Team Breakout Sessions",
            Details = "A chance for each team to get together and catch up",
            Start = new DateTime(2022, 12, 8, 14, 15, 0),
            End = new DateTime(2022, 12, 8, 15, 0, 0),
            Day = EventDay.Thursday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Azyra Quiz",
            Details = "A light hearted and fun Azyra quiz",
            Start = new DateTime(2022, 12, 8, 15, 0, 0),
            End = new DateTime(2022, 12, 8, 16, 0, 0),
            Day = EventDay.Thursday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Team Bonding",
            Details = "Games and fun activities",
            Start = new DateTime(2022, 12, 8, 16, 0, 0),
            End = new DateTime(2022, 12, 8, 17, 0, 0),
            Day = EventDay.Thursday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Dinner",
            Details = "Optional dinner booked in the Herbert Park Hotel",
            Start = new DateTime(2022, 12, 8, 19, 0, 0),
            End = new DateTime(2022, 12, 8, 21, 0, 0),
            Day = EventDay.Thursday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Monthly Update",
            Details = "The December monthly update announcement delivered by Jimmy Cahill",
            Start = new DateTime(2022, 12, 9, 9, 0, 0),
            End = new DateTime(2022, 12, 9, 10, 0, 0),
            Day = EventDay.Friday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Show and Tell",
            Details = "30 minute presentations delivered by Azyra employees about something that interests them",
            Start = new DateTime(2022, 12, 9, 10, 0, 0),
            End = new DateTime(2022, 12, 9, 11, 30, 0),
            Day = EventDay.Friday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Lunch",
            Details = "Sandwiches provided in the Herbert Park Hotel",
            Start = new DateTime(2022, 12, 9, 11, 30, 0),
            End = new DateTime(2022, 12, 9, 12, 30, 0),
            Day = EventDay.Friday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Guinness Storehouse",
            Details = "A fun trip to the Guinness Storehouse. A bus will depart the Herbert Park Hotel at 12:30 aiming to return to the hotel for 16:00.",
            Start = new DateTime(2022, 12, 9, 12, 30, 0),
            End = new DateTime(2022, 12, 9, 16, 0, 0),
            Day = EventDay.Friday,
            Location = "Herbert Park Hotel",
        });

        eventsList.Add(new Event
        {
            Id = Guid.NewGuid(),
            Title = "Christmas Party",
            Details = "The grand finale, dinner in Roly's Bistro.",
            Start = new DateTime(2022, 12, 9, 20, 0, 0),
            End = new DateTime(2022, 12, 9, 23, 0, 0),
            Day = EventDay.Friday,
            Location = "Roly's Bistro",
        });

        return eventsList;
    }
}