using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class CountryRepository : Repository<CountryModel>,ICountryRepository
    {
        private readonly AppDbContext _context;
        public CountryRepository(AppDbContext context) : base(context)
        {
            _context = context;   
        }

        public async Task<CountryModel?> GetByName(string name)
        {
            return await _context.Countries.FindAsync(name);
        }
    }
}
