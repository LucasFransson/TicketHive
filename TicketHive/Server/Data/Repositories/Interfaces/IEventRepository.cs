using IdentityModel;
using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<EventModel>
    {
        Task<IEnumerable<EventModel>?> GetAllWithIncludesAsync();
        Task<EventModel?> GetOneWithIncludesAsync(int id);
        Task<bool> RemoveByIdAsync(int id);
        
    }
}
