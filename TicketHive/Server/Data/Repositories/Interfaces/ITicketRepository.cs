using System.Linq.Expressions;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ITicketRepository : IRepository<TicketModel>
    {
        Task<IEnumerable<TicketModel>?> GetAllWithIncludesAsync();
        //object GetAsync(Expression<Func<TicketDTO, bool>> predicate);
        Task<TicketModel?> GetOneByIdWithIncludesAsync(int id);
        Task<TicketModel?> GetByEventIdAsync(int id);
        Task<bool> RemoveByIdAsync(int id);
    }
}
