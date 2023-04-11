using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public required int MaxUsers { get; set; }
        public bool IsSoldOut => (MaxUsers <= SoldTickets?.Count) ? true : false; 
        public required decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<SoldTicketModel>? SoldTickets { get; set; } 

        [ForeignKey(nameof(Country))]
        public required string CountryName { get; set; }
        public CountryModel? Country { get; set; }
        [ForeignKey(nameof(EventType))]
        public required string EventTypeName { get; set; }
        public EventTypeModel? EventType { get; set; }

        public EventModel()
        {
            
        }
        public EventModel(EventDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            MaxUsers = dto.MaxUsers;
            Price = dto.Price;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            //SoldTickets = dto.SoldTickets hur lösa bäst
            CountryName = dto.CountryName;
            EventTypeName = dto.EventTypeName;
        }
    }
}
