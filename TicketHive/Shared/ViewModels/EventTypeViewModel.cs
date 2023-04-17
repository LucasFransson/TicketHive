using System.ComponentModel.DataAnnotations;
using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.ViewModels
{
    public class EventTypeViewModel
    {
        public string Name { get; set; }

        public EventTypeViewModel()
        {
        }
        // Constructor for ViewModel from DTO
        public EventTypeViewModel(EventTypeDTO etDto)
        {
            Name = etDto.Name;
        }
    }
}
