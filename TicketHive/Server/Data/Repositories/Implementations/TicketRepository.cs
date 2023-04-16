using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class TicketRepository : Repository<TicketModel>,ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketModel>?> GetAllWithIncludesAsync()
        {
            return await _context.Tickets
                .Include(t => t.Event)
                .ThenInclude(e => e.Country)
                .Include(t => t.Event)
                .ThenInclude(e => e.EventType)
                .ToListAsync();
        }

        public async Task<TicketModel?> GetOneByIdWithIncludesAsync(int id)
        {
            return await _context.Tickets
                .Include(t => t.Event)
                .ThenInclude(e => e.Country)
                .Include(t => t.Event)
                .ThenInclude(e => e.EventType)
                .FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<TicketModel?> GetByEventIdAsync(int id)
        {
            return await _context.Tickets
                .Include(t => t.Event)
                .ThenInclude(e => e.Country)
                .Include(t => t.Event)
                .ThenInclude(e => e.EventType)
                .FirstOrDefaultAsync(t => t.EventId.Equals(id));
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            TicketModel? ticketToDelete = await base._context.Tickets.FindAsync(id);

            if (ticketToDelete is not null)
            {
                base._context.Tickets.Remove(ticketToDelete);
                await base._context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
