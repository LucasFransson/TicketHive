using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.StaticMethods;

public static class TransformToDTO
{
    public static SoldTicketDTO FromSoldTicketModel(SoldTicketModel soldTicketModel)
    {
        SoldTicketDTO soldTicketDTO = new(soldTicketModel.Id,
                                          soldTicketModel.EventId,
                                          soldTicketModel.Username,
                                          soldTicketModel.Price,
                                          soldTicketModel.StartTime,
                                          soldTicketModel.EndTime);

        return soldTicketDTO;
    }

    public static TicketDTO FromTicketModel(TicketModel ticketModel)
    {

        if (ticketModel.Event == null)
        {
            throw new Exception("TicketModel Event property is null");
        }

        EventTypeDTO eventTypeDTO = new(ticketModel.Event.EventType.Name);

        CountryDTO countryDTO = new(ticketModel.Event.Country.Name,
                                    ticketModel.Event.Country.Currency,
                                    ticketModel.Event.Country.IsAvailableForUserRegistration);

        EventDTO eventDTO = new(ticketModel.Event.Id,
                                ticketModel.Event.Name,
                                ticketModel.Event.Description,
                                ticketModel.Event.ImageString,
                                ticketModel.Event.MaxUsers,
                                ticketModel.Event.SoldTickets.Count(),
                                ticketModel.Event.TicketsLeft,
                                ticketModel.Event.Price,
                                ticketModel.Event.StartTime,
                                ticketModel.Event.EndTime,
                                ticketModel.Event.CountryName,
                                countryDTO,
                                ticketModel.Event.EventTypeName,
                                eventTypeDTO);

        TicketDTO ticketDTO = new(ticketModel.Id,
                                  ticketModel.EventId,
                                  eventDTO,
                                  ticketModel.Price,
                                  ticketModel.StartTime,
                                  ticketModel.EndTime);

        return ticketDTO;
    }
    //EventTypeDTO eventTypeDTO = new(ticketModel.Event.EventType.Name);

    //CountryDTO countryDTO = new(ticketModel.Event.Country.Name,
    //                            ticketModel.Event.Country.Currency,
    //                            ticketModel.Event.Country.IsAvailableForUserRegistration);

    //EventDTO eventDTO = new(ticketModel.Event.Id,
    //                        ticketModel.Event.Name,
    //                        ticketModel.Event.Description,
    //                        ticketModel.Event.ImageString,
    //                        ticketModel.Event.MaxUsers,
    //                        ticketModel.Event.SoldTickets.Count(),
    //                        ticketModel.Event.TicketsLeft,
    //                        ticketModel.Event.Price,
    //                        ticketModel.Event.StartTime,
    //                        ticketModel.Event.EndTime,
    //                        ticketModel.Event.CountryName,
    //                        countryDTO,
    //                        ticketModel.Event.EventTypeName,
    //                        eventTypeDTO);

    //TicketDTO ticketDTO = new(ticketModel.Id,
    //                          ticketModel.EventId,
    //                          eventDTO,
    //                          ticketModel.Price,
    //                          ticketModel.StartTime,
    //                          ticketModel.EndTime);

    //return ticketDTO;
}
