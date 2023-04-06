using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.DTOs;

namespace TicketHive.Shared.DTO
{
    public class SoldTicketViewModel
    {
        public int Id { get; set; }
        public EventViewModel Event { get; set; }
        public string Username { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public SoldTicketViewModel(SoldTicketDto soldTicketDto)
        {
            Id = soldTicketDto.Id;
            Event = soldTicketDto.Event;
            //Event = new EventViewModel(soldTicketDto.Event.Name, soldTicketDto.Event.MaxUsers, soldTicketDto.Event.Price, new CountryViewModel(soldTicketDto.Event.Country.Name, soldTicketDto.Event.Country.Currency, soldTicketDto.Event.Country.IsAvailableForUserRegistration));
            Username = soldTicketDto.Username;
            Price = soldTicketDto.Price;
            StartTime = soldTicketDto.StartTime;
            EndTime = soldTicketDto.EndTime;
        }
    }
}

