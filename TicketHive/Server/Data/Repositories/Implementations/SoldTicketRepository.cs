using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class SoldTicketRepository : Repository<SoldTicketModel>, ISoldTicketRepository
    {
        private readonly AppDbContext _context;
        public SoldTicketRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<SoldTicketModel>?> GetUserTicketsAsync(string username)
        {
            return await _context.SoldTickets
                .Include(st => st.Event)
                .ThenInclude(e => e.Country)
                .Include(st => st.Event)
                .ThenInclude(e => e.EventType)
                .Where(st => st.Username.Equals(username))
                .ToListAsync();
        }

        public async Task<SoldTicketModel?> GetOneByIdWithIncludesAsync(int id)
        {
            return await _context.SoldTickets
                .Include(st => st.Event)
                .ThenInclude(e => e.Country)
                .Include(st => st.Event)
                .ThenInclude(e => e.EventType)
                .FirstOrDefaultAsync(st => st.Id.Equals(id));
        }
    }
}
