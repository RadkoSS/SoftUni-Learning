namespace Homies.Services;

using Microsoft.EntityFrameworkCore;

using Data;
using Contracts;
using ViewModels.Type;
using ViewModels.Event;
using Data.Models.Entities;

using Event = Data.Models.Entities.Event;

public class EventService : IEventService
{
    private readonly HomiesDbContext dbContext;

    public EventService(HomiesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<AllEventsViewModel[]> GetAllEventsAsync()
    {
        var events =  await this.dbContext.Events.AsNoTracking().Select(e => new AllEventsViewModel
        {
            Id = e.Id,
            Name = e.Name,
            Organiser = e.Organiser.UserName,
            Start = e.Start.ToString("u"),
            Type = e.Type.Name
        }).ToArrayAsync();

        return events;
    }

    public async Task<TypeViewModel[]> GetEventTypesAsync()
    {
        var types = await this.dbContext.Types.AsNoTracking().Select(t => new TypeViewModel
        {
            Id = t.Id,
            Name = t.Name
        }).ToArrayAsync();

        return types;
    }

    public async Task<EventCreateViewAndInputModel> GetCreateAsync()
    {
        var model = new EventCreateViewAndInputModel
        {
            Types = await this.GetEventTypesAsync()
        };

        return model;
    }

    public async Task AddEventAsync(EventCreateViewAndInputModel input, string organiserId)
    {
        var startIsDate = DateTime.TryParse(input.Start, out var startDate);

        var endDateIsDate = DateTime.TryParse(input.End, out var endDate);

        var typeExists = await this.dbContext.Types.AnyAsync(t => t.Id == input.TypeId);

        if (!startIsDate || !endDateIsDate || startDate > endDate || !typeExists)
        {
            throw new InvalidDataException("Invalid data!");
        }

        var newEvent = new Event
        {
            Name = input.Name!,
            Description = input.Description!,
            OrganiserId = organiserId,
            Start = startDate,
            End = endDate,
            TypeId = input.TypeId
        };

        await this.dbContext.Events.AddAsync(newEvent);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<AllEventsViewModel[]> GetJoinedEventsAsync(string organiserId)
    {
        var events = await this.dbContext.EventParticipants.AsNoTracking().Where(ep => ep.HelperId == organiserId).Select(ep => new AllEventsViewModel
        {
            Name = ep.Event.Name,
            Start = ep.Event.Start.ToString("u"),
            Type = ep.Event.Type.Name,
            Id = ep.Event.Id
        }).ToArrayAsync();

        return events;
    }

    public async Task JoinEventAsync(int eventId, string userId)
    {
        var joined = await this.dbContext.EventParticipants.AnyAsync(ep => ep.EventId == eventId && ep.HelperId == userId);

        var eventExists = await this.dbContext.Events.AnyAsync(e => e.Id == eventId);

        if (joined || !eventExists)
        {
            throw new InvalidOperationException("Event not existing or already joined!");
        }

        var newJoinedEvent = new EventParticipant
        {
            HelperId = userId,
            EventId = eventId
        };

        await dbContext.EventParticipants.AddAsync(newJoinedEvent);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task LeaveEventAsync(int eventId, string userId)
    {
        var eventToLeave = await this.dbContext.EventParticipants.FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.HelperId == userId);

        if (eventToLeave != null)
        {
            this.dbContext.EventParticipants.Remove(eventToLeave);

            await this.dbContext.SaveChangesAsync();
        }
    }

    public async Task<EventCreateViewAndInputModel> GetEditAsync(int eventId)
    {
        var eventViewModel = await this.dbContext.Events.AsNoTracking().Where(e => e.Id == eventId).Select(e =>
            new EventCreateViewAndInputModel
            {
                Name = e.Name,
                Description = e.Description,
                Start = e.Start.ToString("u"),
                End = e.End.ToString("u"),
                TypeId = e.TypeId,
            }).FirstAsync();

        eventViewModel.Types = await GetEventTypesAsync();

        return eventViewModel;
    }

    public async Task UpdateEventAsync(EventCreateViewAndInputModel input)
    {
        var startIsDate = DateTime.TryParse(input.Start, out var startDate);

        var endDateIsDate = DateTime.TryParse(input.End, out var endDate);

        var typeExists = await this.dbContext.Types.AnyAsync(t => t.Id == input.TypeId);

        var eventToUpdate = await this.dbContext.Events.FirstOrDefaultAsync(e => e.Id == input.EventId);

        if (!startIsDate || !endDateIsDate || startDate > endDate || !typeExists || eventToUpdate == null || startDate < eventToUpdate.Start)
        {
            throw new InvalidDataException("Invalid data!");
        }

        eventToUpdate.Name = input.Name!;
        eventToUpdate.Description = input.Description!;
        eventToUpdate.Start = startDate;
        eventToUpdate.End = endDate;
        eventToUpdate.TypeId = input.TypeId;

        await this.dbContext.SaveChangesAsync();
    }

    public async Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId)
    {
        var searchedEvent = await this.dbContext.Events.AsNoTracking().FirstOrDefaultAsync(e => e.Id == eventId);

        if (searchedEvent == null)
        {
            throw new InvalidOperationException("Event does not exist!");
        }

        var type = await this.dbContext.Events.Include(e => e.Type).Where(e => e.Id == eventId).Select(t => new
        {
            t.Type.Name
        }).FirstAsync();

        var typeName = type.Name;

        var organiser = await this.dbContext.Events.Include(e => e.Organiser).Where(e => e.Id == eventId).Select(o => new
        {
            o.Organiser.UserName
        }).FirstAsync();

        var organiserName = organiser.UserName!;

        var eventViewModel = new EventDetailsViewModel
        {
            Id = searchedEvent.Id,
            Name = searchedEvent.Name,
            Description = searchedEvent.Description,
            CreatedOn = searchedEvent.CreatedOn.ToString("u"),
            End = searchedEvent.End.ToString("u"),
            Start = searchedEvent.Start.ToString("u"),
            Organiser = organiserName,
            Type = typeName
        };

        return eventViewModel;
    }
}