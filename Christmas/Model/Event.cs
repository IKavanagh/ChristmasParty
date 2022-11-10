namespace Christmas.Model;

public class Event
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public EventDay Day { get; set; }
    public string Location { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Image { get; set; }
    public TimeSpan Duration => End - Start;
    public TimeSpan Time => Start.TimeOfDay;
    public DateTime Date => Start.Date;

    public string StartTime { get; set; }
    public string EndTime { get; set; }
}

public enum EventDay
{
    Thursday = 0,
    Friday = 1
}