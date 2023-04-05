using Microsoft.EntityFrameworkCore;
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

        public async Task<List<EventViewModel>> GetAllAsync()
        {
            List<EventModel> eventModels = await _context.Events.ToListAsync();

            List<EventViewModel> eventViewModels = eventModels.Select(em => (EventViewModel) ConvertToViewModel<EventModel>.ReturnViewModel(em)).ToList();

            return eventViewModels;
        }


    }
}
