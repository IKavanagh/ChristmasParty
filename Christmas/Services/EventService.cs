using Christmas.Model;

namespace Christmas.Services;
public class EventService : BaseService
{
    #region Configuration Parameters
    private static string EventsUrl => "events.json";
    #endregion

    public async Task<List<Event>> GetEvents()
    {
        return await GetAsync<List<Event>>(EventsUrl);
    }
}