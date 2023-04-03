using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class TicketRepository : Repository<TicketModel>,ITicketRepository
    {
        private readonly AppDbContext _appDbContext;
        public TicketRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
