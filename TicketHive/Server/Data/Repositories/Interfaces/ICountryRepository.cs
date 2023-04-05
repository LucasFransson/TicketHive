using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ICountryRepository : IRepository<CountryModel>
    {
        Task<CountryModel> GetByName(string name);
    }
}
