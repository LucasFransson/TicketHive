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
    }
}
