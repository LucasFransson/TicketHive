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

        // Constructor for Model
        public EventDTO(int id, string name, string description, int maxUsers, int ticketsLeft, bool isSoldOut, decimal price, DateTime startTime, DateTime endTime, string countryName, CountryDTO country, string eventTypeName, EventTypeDTO eventType, string? imageString)
        {
            Id = id;
            Name = name;
            Description = description;
            MaxUsers = maxUsers;
            TicketsLeft = ticketsLeft;
            Price = price;
            StartTime = startTime;
            EndTime = endTime;
            CountryName = countryName;
            Country = country;
            EventTypeName = eventTypeName;
            EventType = eventType;
            ImageString = imageString;
        }



        //// Constructor for ViewModel
        //public EventDTO(EventViewModel viewModel)
        //{
        //    Id = viewModel.Id;
        //    Name = viewModel.Name;
        //    Description = viewModel.Description;
        //    MaxUsers = viewModel.MaxUsers;
        //    TicketsLeft = viewModel.TicketsLeft;
        //    IsSoldOut = viewModel.TicketsLeft == 0;
        //    Price = viewModel.Price;
        //    StartTime = viewModel.StartTime;
        //    EndTime = viewModel.EndTime;
        //    CountryName = viewModel.CountryName;
        //    Country = viewModel.Country != null ? new CountryDTO(viewModel.Country.Name, viewModel.Country.Currency, viewModel.Country.IsAvailableForUserRegistration) : null;
        //    EventTypeName = viewModel.EventTypeName;
        //    EventType = viewModel.EventType != null ? new EventTypeDTO(viewModel.EventType.Name) : null;
        //}

        //public EventDTO()
        //{
        //    Id = model.Id;
        //    Name = model.Name;
        //    Description = model.Description;
        //    MaxUsers = model.MaxUsers;
        //    TicketsLeft = model.SoldTickets != null ? model.MaxUsers - model.SoldTickets.Count : model.MaxUsers;
        //    IsSoldOut = model.IsSoldOut;
        //    Price = model.Price;
        //    StartTime = model.StartTime;
        //    EndTime = model.EndTime;
        //    CountryName = model.CountryName;
        //    Country = model.Country != null ? new CountryDTO(model.Country) : null;
        //    EventTypeName = model.EventTypeName;
        //    EventType = model.EventType != null ? new EventTypeDTO(model.EventType) : null;
        //}

        //// Constructor for Model
        //public EventDTO(int id, string name, string description, int maxUsers, int ticketsLeft, decimal price, DateTime start, DateTime end, string countryName, CountryDTO cDto, EventTypeDTO eDto, string eventTypeName, )
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    MaxUsers = maxUsers;
        //    TicketsLeft = ticketsLeft;
        //    Price = price;
        //    StartTime = start;
        //    EndTime = end;
        //    CountryName = countryName;
        //    Country = cDto;
        //    EventType = eDto;
        //    EventTypeName = eventTypeName;


        //}

        //// Constructor for ViewModel
        //public EventDTO(EventViewModel viewModel)
        //{
        //    Id = viewModel.Id;
        //    Name = viewModel.Name;
        //    Description = viewModel.Description;
        //    MaxUsers = viewModel.MaxUsers;
        //    TicketsLeft = viewModel.TicketsLeft;
        //    Price = viewModel.Price;
        //    StartTime = viewModel.StartTime;
        //    EndTime = viewModel.EndTime;
        //    CountryName = viewModel.CountryName;
        //    Country = viewModel.Country;
        //    EventType = viewModel.EventType;
        //    EventTypeName = viewModel.EventTypeName;
        //}

        //// Empty constructor
        //public EventDTO()
        //{

        //}

    }
}
