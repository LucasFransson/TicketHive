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
                    return ConvertCountryModel(entity as CountryModel);
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
            Events = ConvertListOfEventModels(eventTypeModel.Events)
        };

        return eventTypeViewModel;
    }

    private static List<EventViewModel>? ConvertListOfEventModels(List<EventModel> eventModels)
    {
        List<EventViewModel>? eventViewModels = eventModels.Select(e => ConvertEventModel(e)).ToList();

        return eventViewModels;
    }

    private static EventViewModel ConvertEventModel(EventModel eventModel)
    {
        EventViewModel eventViewModel = new()
        {
            Id = eventModel.Id,
            Name = eventModel.Name,
            Description = eventModel.Description,
            MaxUsers = eventModel.MaxUsers,
            IsSoldOut = eventModel.IsSoldOut,
            Price = eventModel.Price,
            //StartTime = eventModel.StartTime,
            //EndTime = eventModel.EndTime,
            SoldTickets = ConvertListOfTicketModels(eventModel.SoldTickets),
            Country = ConvertCountryModel(eventModel.Country),
            EventType = ConvertEventTypeModel(eventModel.EventType)
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
            Event = ConvertEventModel(ticketModel.Event),
            Username = ticketModel.Username,
            Price = ticketModel.Price,
            //StartTime = ticketModel.StartTime,
            //EndTime = ticketModel.EndTime
        };

        return ticketViewModel;
    }

    private static List<TicketViewModel>? ConvertListOfTicketModels(List<TicketModel> eventModels)
    {
        List<TicketViewModel>? ticketViewModels = eventModels.Select(t => ConvertTicketModel(t)).ToList();

        return ticketViewModels;
    }
}
 
