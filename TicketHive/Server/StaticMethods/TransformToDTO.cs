using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.StaticMethods;

public static class TransformToDTO
{
    public static SoldTicketDTO FromSoldTicketModel(SoldTicketModel soldTicketModel)
    {
        EventTypeDTO eventTypeDTO = new(soldTicketModel.Event.EventType.Name);

        CountryDTO countryDTO = new(soldTicketModel.Event.Country.Name, soldTicketModel.Event.Country.Currency, soldTicketModel.Event.Country.IsAvailableForUserRegistration);

        EventDTO eventDTO = new(soldTicketModel.Event.Id, soldTicketModel.Event.Name, soldTicketModel.Event.Description, soldTicketModel.Event.ImageString, soldTicketModel.Event.MaxUsers, soldTicketModel.Event.TicketsLeft, soldTicketModel.Event.Price, soldTicketModel.Event.StartTime, soldTicketModel.Event.EndTime, soldTicketModel.Event.CountryName, countryDTO, soldTicketModel.Event.EventTypeName, eventTypeDTO);

        SoldTicketDTO soldTicketDTO = new(soldTicketModel.Id, soldTicketModel.EventId, eventDTO, soldTicketModel.Username, soldTicketModel.Price, soldTicketModel.StartTime, soldTicketModel.EndTime);

        return soldTicketDTO;
    }

    public static TicketDTO FromTicketModel(TicketModel ticketModel)
    {
            EventTypeDTO eventTypeDTO = new(ticketModel.Event.EventType.Name);

            CountryDTO countryDTO = new(ticketModel.Event.Country.Name, ticketModel.Event.Country.Currency, ticketModel.Event.Country.IsAvailableForUserRegistration);

            EventDTO eventDTO = new(ticketModel.Event.Id, ticketModel.Event.Name, ticketModel.Event.Description, ticketModel.Event.ImageString, ticketModel.Event.MaxUsers, ticketModel.Event.TicketsLeft, ticketModel.Event.Price, ticketModel.Event.StartTime, ticketModel.Event.EndTime, ticketModel.Event.CountryName, countryDTO, ticketModel.Event.EventTypeName, eventTypeDTO);

            TicketDTO ticketDTO = new(ticketModel.Id, ticketModel.EventId, eventDTO, ticketModel.Price, ticketModel.StartTime, ticketModel.EndTime);

            return ticketDTO;
    }
}
