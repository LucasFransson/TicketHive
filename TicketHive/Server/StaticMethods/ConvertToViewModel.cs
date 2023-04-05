using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.StaticMethods;

public static class ConvertToViewModel<TEntity>
{
    public static Object ReturnViewModel(TEntity entity)
    {
        switch (entity.GetType().Name)
        {
            case "CountryModel":
                {
                    
                    CountryViewModel countryViewModel = ConvertCountryModel(entity as CountryModel);
                    return countryViewModel;
                }
            case "EventModel":
                {
                    //EventModel? test = entity as EventModel;
                    return ConvertEventModel(entity as EventModel);
                }
            case "EventTypeModel":
                {
                    return ConvertEventTypeModel(entity as EventTypeModel);
                }
            case "TicketModel":
                {
                    return ConvertTicketModel(entity as TicketModel);
                }

            default: throw new ArgumentException("Invalid Model type.");
        }
    }

    private static EventTypeViewModel ConvertEventTypeModel(EventTypeModel eventTypeModel)
    {
        EventTypeViewModel eventTypeViewModel = new()
        {
            Name = eventTypeModel.Name,
            Events = null,
        };

        return eventTypeViewModel;
    }

    private static EventViewModel ConvertEventModel(EventModel eventModel)
    {
        EventViewModel eventViewModel = new()
        {
            Id = eventModel.Id,
            Name = eventModel.Name,
            Description = eventModel.Description,
            MaxUsers = eventModel.MaxUsers,
            Price = eventModel.Price,
            StartTime = eventModel.StartTime,
            EndTime = eventModel.EndTime,
            SoldTickets = null,
            Country = null,
            EventType = null,
        };

        return eventViewModel;
    }

    private static CountryViewModel ConvertCountryModel(CountryModel countryModel)
    {

        CountryViewModel countryViewModel = new()
        {
            Name = countryModel.Name,
            Currency = countryModel.Currency,
            IsAvailableForUserRegistration = countryModel.IsAvailableForUserRegistration,
        };

        return countryViewModel;
    }

    private static TicketViewModel ConvertTicketModel(TicketModel ticketModel)
    {
        TicketViewModel ticketViewModel = new()
        {
            Id = ticketModel.Id,
            Event = null,
            Username = ticketModel.Username,
            Price = ticketModel.Price,
            StartTime = ticketModel.StartTime,
            EndTime = ticketModel.EndTime
        };

        return ticketViewModel;
    }
}
 
