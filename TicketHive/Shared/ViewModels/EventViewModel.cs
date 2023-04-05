using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketHive.Shared.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MaxUsers { get; set; }
        public bool IsSoldOut => (MaxUsers <= SoldTickets?.Count) ? true : false; 
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<TicketViewModel> SoldTickets { get; set; } = new();
        public string CountryName { get; set; }
        public  CountryViewModel Country { get; set; }
        public  EventTypeViewModel EventType { get; set; }
        public string EventTypeName { get; set; }
    }
}
