using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class EventTypeRepository : Repository<EventTypeModel>, IEventTypeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EventTypeRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

    }
}
