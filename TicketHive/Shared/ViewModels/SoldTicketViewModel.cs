using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.DTOs;
using TicketHive.Shared.ViewModels;


namespace TicketHive.Shared.DTO
{
    public class SoldTicketViewModel
    {
        public int Id { get; set; }
        public int EventID { get; set; }
        public EventViewModel? Event { get; set; }
        //public string EventName { get; set; }
        public string Username { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public SoldTicketViewModel()
        {
            
        }

        public SoldTicketViewModel(SoldTicketDTO dto)
        {
            Id = dto.Id;
            EventID = dto.EventId;
            Event = new EventViewModel(dto.Event);
            Username = dto.Username;
            Price = dto.Price;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            
        }

        // Constructor for SoldTicketViewModel from DTO
        //public SoldTicketViewModel(SoldTicketDTO soldTicketDto)
        //{
        //    Id = soldTicketDto.Id;
        //    EventID = soldTicketDto.EventId;

        //    if (soldTicketDto.Event != null)
        //    {
        //        var countryViewModel = soldTicketDto.Event.Country != null
        //            ? new CountryViewModel(soldTicketDto)
        //            : null;
        //        Event = new EventViewModel(soldTicketDto,countryViewModel);
        //    }   
        //    Username = soldTicketDto.Username;
        //    Price = soldTicketDto.Price;
        //    StartTime = soldTicketDto.StartTime;
        //    EndTime = soldTicketDto.EndTime;

        //if(soldTicketDto.Event is not null) 
        //{ 
        //    EventViewModel eventViewModel = new EventViewModel { 
        //        Id= soldTicketDto.Event.Id,
        //        Name= soldTicketDto.Event.Name,
        //        Description = soldTicketDto.Event.Description,
        //        MaxUsers= soldTicketDto.Event.MaxUsers,
        //        TicketsLeft= soldTicketDto.Event.TicketsLeft,
        //        Price = soldTicketDto.Event.Price,
        //        StartTime = soldTicketDto.Event.StartTime,
        //        EndTime = soldTicketDto.Event.EndTime,
        //        if(eventViewModel.Country is not null)
        //    {

        //    }


        //    };
        //}
        //Event = soldTicketDto.Event;


        //Event = new EventViewModel(soldTicketDto.Event.Name, soldTicketDto.Event.MaxUsers, soldTicketDto.Event.Price, new CountryViewModel(soldTicketDto.Event.Country.Name, soldTicketDto.Event.Country.Currency, soldTicketDto.Event.Country.IsAvailableForUserRegistration));

    }
    }
}

