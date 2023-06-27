namespace Homies.Services.Contracts;

using ViewModels.Type;
using ViewModels.Event;

public interface IEventService
{
    Task<AllEventsViewModel[]> GetAllEventsAsync();

    Task<TypeViewModel[]> GetEventTypesAsync();

    Task<EventCreateViewAndInputModel> GetCreateAsync();

    Task AddEventAsync(EventCreateViewAndInputModel input, string userId);

    Task<AllEventsViewModel[]> GetJoinedEventsAsync(string userId);

    Task JoinEventAsync(int eventId, string userId);

    Task LeaveEventAsync(int eventId, string userId);

    Task<EventCreateViewAndInputModel> GetEditAsync(int eventId, string userId);

    Task UpdateEventAsync(EventCreateViewAndInputModel input);

    Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId);
}