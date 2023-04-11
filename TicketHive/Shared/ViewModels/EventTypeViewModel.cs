using System.ComponentModel.DataAnnotations;
using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.ViewModels
{
    public class EventTypeViewModel
    {
        public string Name { get; set; }
        //public List<EventViewModel>? Events { get; set; } = new();    // Not using this due to ticket size, or use without tickets to bring down size

        public EventTypeViewModel()
        {
            
        }

        public EventTypeViewModel(EventTypeDTO etDto)
        {
            Name = etDto.Name;
        }
    }
}
