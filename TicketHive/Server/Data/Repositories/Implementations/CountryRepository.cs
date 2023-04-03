using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class CountryRepository : Repository<CountryModel>,ICountryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CountryRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;   
        }
    }
}
