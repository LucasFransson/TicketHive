﻿using TicketHive.Server.Data.Repositories.Implementations;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ISoldTicketRepository : IRepository<SoldTicketModel>
    {
        Task<IEnumerable<SoldTicketModel>?> GetUserTicketsAsync(string username);
        Task<SoldTicketModel?> GetOneByIdWithIncludesAsync(int id);
    }
}
