﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Data.Repositories.Implementations
{
    public class TicketRepository : Repository<TicketModel>,ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<TicketModel>?> GetAllTicketsAsync()
        //{
        //    return await _context.Tickets
        //        .Include(t => t.Event)
        //        .ThenInclude(e => e.Country)
        //        .Include(t => t.Event)
        //        .ThenInclude(e => e.EventType)
        //         .Include(t => t.Event)
        //        .ThenInclude(e => e.SoldTickets)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<TicketModel?>> GetByEventIdAsync(int id,int quantity)
        {
            return await _context.Tickets
                            .Include(t => t.Event)
                            .ThenInclude(e => e.Country)
                            .Include(t => t.Event)
                            .ThenInclude(e => e.EventType)
                            .Include(t => t.Event)
                            .ThenInclude(e => e.SoldTickets)
                            .Where(t => t.EventId.Equals(id))
                            .Take(quantity)
                            .ToListAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            TicketModel? ticketToDelete = await base._context.Tickets.FindAsync(id);

            if (ticketToDelete is not null)
            {
                base._context.Tickets.Remove(ticketToDelete);
                await base._context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
