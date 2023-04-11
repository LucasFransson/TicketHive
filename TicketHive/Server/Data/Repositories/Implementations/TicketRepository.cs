using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class TicketRepository : Repository<TicketModel>,ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context) : base(context)
        {
            _context = context;
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
