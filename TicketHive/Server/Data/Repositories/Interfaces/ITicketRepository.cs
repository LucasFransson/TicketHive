using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ITicketRepository : IRepository<TicketModel>
    {
        Task<IEnumerable<TicketModel>?> GetAllWithIncludesAsync();
        Task<TicketModel?> GetOneByIdWithIncludesAsync(int id);
        Task<bool> RemoveByIdAsync(int id);
    }
}
