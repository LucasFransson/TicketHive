using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ICountryRepository : IRepository<CountryModel>
    {
        Task<CountryViewModel>? GetByName(string name);
    }
}
