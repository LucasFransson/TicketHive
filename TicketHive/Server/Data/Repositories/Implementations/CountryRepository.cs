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

        public async Task<List<CountryViewModel>> GetAllAsync()
        {
            List<CountryModel> countryModels = await _context.Countries.ToListAsync();

            return countryModels.Select(cm => (CountryViewModel) ConvertToViewModel<CountryModel>.ReturnViewModel(cm)).ToList();
        }


        public async Task<CountryViewModel?> GetByName(string name)
        {
            var selectedEntity = await _context.Countries.FindAsync(name);

            return (CountryViewModel?) ConvertToViewModel<CountryModel>.ReturnViewModel(selectedEntity);
        }
    }
}
