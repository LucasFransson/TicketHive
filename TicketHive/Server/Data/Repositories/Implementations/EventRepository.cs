﻿using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Server.StaticMethods;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class EventRepository : Repository<EventModel>, IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventModel>?> GetAllWithIncludesAsync()
        {
            return (IEnumerable<EventModel>?) await _context.Events.Include(e => e.Country).Include(e => e.EventType).Include(e => e.SoldTickets).ToListAsync();
        }

        public async Task<EventModel?> GetOneWithIncludesAsync(int id)
        {
            return await _context.Events.Include(e => e.Country).Include(e => e.EventType).FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            EventModel? eventToDelete = await _context.Events.FindAsync(id);

            if (eventToDelete is not null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
