﻿using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface ITicketRepository : IRepository<TicketModel>
    {
        Task<bool> RemoveByIdAsync(int id);
    }
}
