using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface IEventTypeRepository : IRepository<EventTypeModel>
    {
        Task<EventTypeModel?> GetByNameAsync(string name);
        Task<bool> RemoveByNameAsync(string name);
    }
}
