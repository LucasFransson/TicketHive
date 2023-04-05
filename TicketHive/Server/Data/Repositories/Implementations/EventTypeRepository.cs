using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Server.StaticMethods;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Implementations;

public class EventTypeRepository : Repository<EventTypeModel>, IEventTypeRepository
{
    private readonly AppDbContext _context;
    public EventTypeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<EventTypeViewModel?> GetByNameAsync(string name)
    {
        EventTypeModel? eventTypeModel = await _context.EventTypes.FindAsync(name);

        return (EventTypeViewModel?)ConvertToViewModel<EventTypeModel>.ReturnViewModel(eventTypeModel);
    }

    public async Task<List<EventTypeViewModel>?> GetAllAsync()
    {
        List<EventTypeModel>? eventTypeModels = await _context.EventTypes.ToListAsync();

        return eventTypeModels.Select(etm => (EventTypeViewModel)ConvertToViewModel<EventTypeModel>.ReturnViewModel(etm)).ToList();
    }
}