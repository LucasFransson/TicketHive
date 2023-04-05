using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface IEventTypeRepository : IRepository<EventTypeModel>
    {
        Task<EventTypeViewModel?> GetByNameAsync(string name);
        Task<List<EventTypeViewModel>?> GetAllAsync();
    }
}
