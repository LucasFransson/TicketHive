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

    public async Task<EventTypeModel?> GetByNameAsync(string name)
    {
        return await _context.EventTypes.FindAsync(name);
    }

    public async Task<bool> RemoveByNameAsync(string name)
    {
        EventTypeModel? eventTypeToDelete = await _context.EventTypes.FindAsync(name);

        if (eventTypeToDelete is not null)
        {
            _context.EventTypes.Remove(eventTypeToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }
}