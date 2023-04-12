using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Shared.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageString { get; set; }
        public int MaxUsers { get; set; }
        public int TicketsLeft { get;  }    
        public bool IsSoldOut { get => TicketsLeft <= 0; } 
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CountryName { get; set; }
        public CountryDTO Country { get; set; }
        public string EventTypeName { get; set; }
        public EventTypeDTO EventType { get; set; }


        public EventDTO()
        {
            
        }

        // Constructor for DTO from Model Input Parameters
        public EventDTO(int id, string name, string description, string? imageString, int maxUsers, int ticketsLeft, decimal price, DateTime startTime, DateTime endTime, string countryName, CountryDTO country, string eventTypeName, EventTypeDTO eventType)
        {
            Id = id;
            Name = name;
            Description = description; 
            ImageString = imageString;
            MaxUsers = maxUsers;
            TicketsLeft = ticketsLeft;
            Price = price;
            StartTime = startTime;
            EndTime = endTime;
            CountryName = countryName;
            Country = country;
            EventTypeName = eventTypeName;
            EventType = eventType;
          
        }
    }
}
