using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Security;
using TicketHive.Shared.DTO;
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
        public int TicketsLeft { get; }
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

        public EventViewModel(EventDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            MaxUsers = dto.MaxUsers;
            TicketsLeft = dto.TicketsLeft;
            CountryName = dto.CountryName;
            Country = new CountryViewModel(dto.Country);
            EventTypeName = dto.EventTypeName;
            EventType = new EventTypeViewModel(dto.EventType);
            ImageString = dto.ImageString;
        }

        //public EventViewModel(EventDTO dto)
        //{
        //    Id = dto.Id;
        //    Name = dto.Name;
        //    Description = dto.Description;
        //    MaxUsers = dto.MaxUsers;
        //    TicketsLeft = dto.TicketsLeft;
        //    Price = dto.Price;
        //    StartTime = dto.StartTime;
        //    EndTime = dto.EndTime;
        //    CountryName = dto.CountryName;
        //    Country = dto.Country != null ? ConvertToViewModel(dto.Country) : null;
        //    EventTypeName = dto.EventTypeName;
        //    EventType = dto.EventType != null ? ConvertToViewModel(dto.EventType) : null;
        //}

        //public static CountryViewModel ConvertToViewModel(CountryDTO dto)
        //{
        //    return new CountryViewModel
        //    {
        //        Name = dto.Name,
        //        Currency = dto.Currency,
        //        IsAvailableForUserRegistration = dto.IsAvailableForUserRegistration
        //    };
        //}
        //public static EventTypeViewModel ConvertToViewModel(EventTypeDTO dto)
        //{
        //    return new EventTypeViewModel
        //    {
        //        Name = dto.Name
        //    };
        //}

        //// Constructor for EventViewModel from DTO
        //public EventViewModel(EventDTO eDto) 
        //{
        //    eDto.Id = eDto.Id;
        //    Name= eDto.Name;
        //    Description= eDto.Description;
        //    MaxUsers = eDto.MaxUsers;
        //    TicketsLeft = eDto.TicketsLeft;
        //    Price = eDto.Price;

        //    if (eDto.Country is not null)
        //    {
        //        CountryViewModel countryViewModel = new CountryViewModel
        //        {
        //            Name = eDto.Country.Name,
        //            Currency = eDto.Country.Currency,
        //            IsAvailableForUserRegistration = eDto.Country.IsAvailableForUserRegistration,
        //        };
        //        Country = countryViewModel;
        //    }

        //    CountryName = eDto.CountryName;
        //    EventTypeName = eDto.EventTypeName;
        //}

        //// Constructor for SoldTicket Related Data
        //public EventViewModel(SoldTicketDTO soldTicketDTO, CountryViewModel soldTicketCountry) 
        //{
        //    Name = soldTicketDTO.Event.Name;
        //    Description = soldTicketDTO.Event.Description;
        //    MaxUsers = soldTicketDTO.Event.MaxUsers;
        //    TicketsLeft = soldTicketDTO.Event.TicketsLeft;
        //    Price = soldTicketDTO.Event.Price;
        //    StartTime = soldTicketDTO.Event.StartTime;
        //    EndTime = soldTicketDTO .EndTime;
        //    Country = soldTicketCountry;
        //    CountryName = soldTicketCountry.Name;


        //}
    }
}
