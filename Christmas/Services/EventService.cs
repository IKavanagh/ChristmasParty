using Christmas.Model;

namespace Christmas.Services;
public class EventService
{
    public List<Event> GetThursdayEvents() => GetEvents().Where(e => e.Day == EventDay.Thursday).ToList();

    public List<Event> GetFridayEvents() => GetEvents().Where(e => e.Day == EventDay.Friday).ToList();

    public List<Event> GetEvents()
    {
        return new()
        {
            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Arrive at Herbert Park Hotel",
                Details = "Travel to Herbert Park Hotel, get checked-in and get ready for the festivities to begin.",
                Start = new DateTime(2022, 12, 8, 9, 0, 0),
                End = new DateTime(2022, 12, 8, 14, 0, 0),
                Day = EventDay.Thursday,
                Location = "Herbert Park Hotel",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Introduction and Opening Session",
                Details = "The conference will be opened with a short introduction and welcome.",
                Start = new DateTime(2022, 12, 8, 14, 0, 0),
                End = new DateTime(2022, 12, 8, 14, 10, 0),
                Day = EventDay.Thursday,
                Location = "Mezzanine Suite",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Team Breakout Sessions",
                Details = "A chance for each team to get together, catch up and discuss.",
                Start = new DateTime(2022, 12, 8, 14, 10, 0),
                End = new DateTime(2022, 12, 8, 15, 0, 0),
                Day = EventDay.Thursday,
                Location = "Mezzanine Suite",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Azyra Quiz",
                Details = "Our quiz master Siobhan will be testing your knowledge on weird Azyra and Christmas facts.",
                Start = new DateTime(2022, 12, 8, 15, 0, 0),
                End = new DateTime(2022, 12, 8, 16, 0, 0),
                Day = EventDay.Thursday,
                Location = "Mezzanine Suite",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Team Bonding",
                Details = "Siobhan will be taking us through some fun light-hearted games and activities.",
                Start = new DateTime(2022, 12, 8, 16, 0, 0),
                End = new DateTime(2022, 12, 8, 17, 0, 0),
                Day = EventDay.Thursday,
                Location = "Mezzanine Suite",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Dinner",
                Details = "[Optional] Dinner has been booked in the Pavilion Restaurant for all those attending the conference. Attendance is entirely optional.",
                Start = new DateTime(2022, 12, 8, 19, 0, 0),
                End = new DateTime(2022, 12, 8, 21, 0, 0),
                Day = EventDay.Thursday,
                Location = "Pavilion Restaurant",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Monthly Update",
                Details = "Jimmy Cahill will be delivering the December monthly update announcement.",
                Start = new DateTime(2022, 12, 9, 9, 0, 0),
                End = new DateTime(2022, 12, 9, 10, 0, 0),
                Day = EventDay.Friday,
                Location = "Mezzanine Suite",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Show and Tell",
                Details = "Some quick presentations delivered by Azyra employees about something that interests them.",
                Start = new DateTime(2022, 12, 9, 10, 0, 0),
                End = new DateTime(2022, 12, 9, 11, 30, 0),
                Day = EventDay.Friday,
                Location = "Mezzanine Suitel",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Lunch",
                Details = "Sandwiches will be provided in the Mezzanine Suite.",
                Start = new DateTime(2022, 12, 9, 11, 30, 0),
                End = new DateTime(2022, 12, 9, 12, 30, 0),
                Day = EventDay.Friday,
                Location = "Mezzanine Suite",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Guinness Storehouse",
                Details = "A fun trip to the Guinness Storehouse. A bus will depart the Herbert Park Hotel at 12:30 aiming to return to the hotel for 16:00.",
                Start = new DateTime(2022, 12, 9, 12, 30, 0),
                End = new DateTime(2022, 12, 9, 16, 0, 0),
                Day = EventDay.Friday,
                Location = "Guinness Storehouse",
            },

            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Christmas Party",
                Details = "The Grand Celebration - Dinner in Roly's Bistro.",
                Start = new DateTime(2022, 12, 9, 20, 0, 0),
                End = new DateTime(2022, 12, 9, 23, 0, 0),
                Day = EventDay.Friday,
                Location = "Roly's Bistro",
            }
        };
    }
}