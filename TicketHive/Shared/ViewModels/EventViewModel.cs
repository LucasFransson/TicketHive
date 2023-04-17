using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Security;

using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageString { get; set; }
        public int MaxUsers { get; set; }
        public int TicketsLeft { get; set; }
        public int SoldTicketsCount { get; set; }
        public bool IsSoldOut => TicketsLeft <= 0;
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CountryName { get; set; }
        public CountryViewModel Country { get; set; }
        public string EventTypeName { get; set; }
        public EventTypeViewModel EventType { get; set; }
      


        public EventViewModel()
        {
            
        }

        // Constructor for ViewModel from DTO
        public EventViewModel(EventDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            MaxUsers = dto.MaxUsers;
            SoldTicketsCount = dto.SoldTicketsCount;
            TicketsLeft = dto.TicketsLeft;
            CountryName = dto.CountryName;
            Country = new CountryViewModel(dto.Country);
            EventTypeName = dto.EventTypeName;
            EventType = new EventTypeViewModel(dto.EventType);
            ImageString = dto.ImageString;
        }
    }
}
