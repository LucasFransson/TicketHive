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
        public TicketViewModel(TicketDTO dto)
        {
            Id = dto.Id;
            EventId = dto.EventId;
            Event = new EventViewModel(dto.Event);
            Price = dto.Price;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
        }


        // Constructor for DTO
        //public TicketViewModel(TicketDTO dto)
        //{
        //    Id = dto.Id;
        //    EventId = dto.EventId;
        //    Event = ConvertToViewModel(dto.Event);
        //    Price = dto.Price;
        //    StartTime = dto.StartTime;
        //    EndTime = dto.EndTime;
        //}


        //public static EventViewModel ConvertToViewModel(EventDTO dto)
        //{
        //    return new EventViewModel
        //    {
        //        Id = dto.Id,
        //        Name = dto.Name,
        //        Description = dto.Description,
        //        MaxUsers = dto.MaxUsers,
        //        TicketsLeft = dto.TicketsLeft,
        //        Price = dto.Price,
        //        StartTime = dto.StartTime,
        //        EndTime = dto.EndTime,
        //        CountryName = dto.CountryName,
        //        Country = dto.Country != null ? CountryViewModel.ConvertToViewModel(dto.Country) : null,
        //        EventTypeName = dto.EventTypeName,
        //        EventType = dto.EventType != null ? EventTypeViewModel.ConvertToViewModel(dto.EventType) : null
        //    };
        //}


        //public TicketViewModel(TicketDTO ticketDto)
        //{
        //    Id = ticketDto.Id;
        //    EventId = ticketDto.EventId;
        //    Event = ticketDto.Event;
        //    Price = ticketDto.Price;
        //    StartTime = ticketDto.StartTime;
        //    EndTime = ticketDto.EndTime;

        //}
    }
}
