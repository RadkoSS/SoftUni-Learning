namespace Homies.Services.Contracts;

using ViewModels.Type;
using ViewModels.Event;

public interface IEventService
{
    Task<AllEventsViewModel[]> GetAllEventsAsync();

    Task<TypeViewModel[]> GetEventTypesAsync();

    Task<EventCreateViewAndInputModel> GetCreateAsync();

    Task AddEventAsync(EventCreateViewAndInputModel input, string organiserId);

    Task<AllEventsViewModel[]> GetJoinedEventsAsync(string organiserId);

    Task JoinEventAsync(int eventId, string userId);

    Task LeaveEventAsync(int eventId, string userId);

    Task<EventCreateViewAndInputModel> GetEditAsync(int eventId);

    Task UpdateEventAsync(EventCreateViewAndInputModel input);

    Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId);
}