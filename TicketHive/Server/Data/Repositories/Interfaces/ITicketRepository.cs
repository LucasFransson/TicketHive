using System.Linq.Expressions;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ITicketRepository : IRepository<TicketModel>
    {
        //Task<IEnumerable<TicketModel>?> GetAllTicketsAsync();

        Task<IEnumerable<TicketModel>> GetByEventIdAsync(int id, int quantity);

        Task<bool> RemoveByIdAsync(int id);
    }
}
