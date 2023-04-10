using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Server.StaticMethods;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class CountryRepository : Repository<CountryModel>,ICountryRepository
    {
        private readonly AppDbContext _context;
        public CountryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CountryModel?> GetByNameAsync(string name)
        {
            return await _context.Countries.FindAsync(name);
        }

        public async Task<bool> RemoveByNameAsync(string name)
        {
            CountryModel? countryToDelete = await _context.Countries.FindAsync(name);

            if (countryToDelete is not null)
            {
                _context.Countries.Remove(countryToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
