﻿using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<EventModel>
    {
        Task<bool> RemoveByIdAsync(int id);
    }
}
