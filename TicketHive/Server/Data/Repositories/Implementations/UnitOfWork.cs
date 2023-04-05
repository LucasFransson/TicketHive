using System.Runtime.CompilerServices;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICountryRepository Countries { get; set; }
        public IEventRepository Events { get; set; }
        public IEventTypeRepository EventTypes { get; set; }
        public ITicketRepository Tickets { get; set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Countries = new CountryRepository(context);
            Events = new EventRepository(context);
            EventTypes = new EventTypeRepository(context);
            Tickets = new TicketRepository(context);
        }
        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
