﻿using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class EventRepository : Repository<EventModel>, IEventRepository
    {
        private readonly AppDbContext _appDbContext;
        public EventRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
