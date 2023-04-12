using System.ComponentModel.DataAnnotations;
using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public EventViewModel Event { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Empty Constructor
        public TicketViewModel()
        {
        }
        // Constructor for ViewModel from DTO
        public TicketViewModel(TicketDTO dto)
        {
            Id = dto.Id;
            EventId = dto.EventId;
            Event = new EventViewModel(dto.Event);
            Price = dto.Price;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
        }
    }
}
