using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public EventsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/<EventsController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDTO>?>> Get()
    {

        IEnumerable<EventDTO>? eventDTOs = (await _unitOfWork.Events.GetAllWithIncludesAsync())?
                                                                 .Select(em => new EventDTO(
                                                                        em.Id,
                                                                        em.Name,
                                                                        em.Description,
                                                                        em.ImageString,
                                                                        em.MaxUsers,
                                                                        em.TicketsLeft,
                                                                        em.SoldTickets?.Count() ?? 0,
                                                                        em.Price,
                                                                        em.StartTime,
                                                                        em.EndTime,
                                                                        em.CountryName,
                                                                        new CountryDTO
                                                                        (
                                                                            em.Country.Name,
                                                                            em.Country.Currency,
                                                                            em.Country.IsAvailableForUserRegistration
                                                                        ),
                                                                        em.EventTypeName,
                                                                        new EventTypeDTO(em.EventType.Name)));

        return Ok(eventDTOs);

        //IEnumerable<EventDTO>? events = (await _unitOfWork.Events.GetAllWithIncludesAsync())
        //                                                 .Select(em => new EventDTO(em.Id,
        //                                                                           em.Name,
        //                                                                           em.Description,
        //                                                                           em.ImageString,
        //                                                                           em.MaxUsers,
        //                                                                           em.TicketsLeft,
        //                                                                           em.Price,
        //                                                                           em.StartTime,
        //                                                                           em.EndTime,
        //                                                                           em.CountryName,
        //                                                                           new CountryDTO(em.CountryName,
        //                                                                                          em.Country.Currency,
        //                                                                                          em.Country.IsAvailableForUserRegistration
        //                                                                                         ),
        //                                                                           em.EventTypeName,
        //                                                                           new EventTypeDTO(em.EventTypeName)
        //                                                                                       ));


        //IEnumerable<EventDTO>? events = (await _unitOfWork.Events.GetAllAsync()).Select(em => new EventDTO
        //{
        //    Id = em.Id,
        //    Name = em.Name,
        //    Description = em.Description,
        //    MaxUsers = em.MaxUsers,
        //    TicketsLeft = em.TicketsLeft,
        //    Price = em.Price,
        //    StartTime = em.StartTime,
        //    EndTime = em.EndTime,
        //    CountryName = em.CountryName,
        //    EventTypeName = em.EventTypeName,
        //});
    }

    // GET api/<EventsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EventDTO>> Get(int id)
    {
        EventModel? eventModel = await _unitOfWork.Events.GetOneWithIncludesAsync(id);
        
        if (eventModel is not null)
        {
            EventDTO eventDTO = new(eventModel.Id,
                                    eventModel.Name,
                                    eventModel.Description,
                                    eventModel.ImageString,
                                    eventModel.MaxUsers,
                                    eventModel.TicketsLeft,
                                    eventModel.SoldTickets?.Count() ?? 0,
                                    eventModel.Price,
                                    eventModel.StartTime,
                                    eventModel.EndTime,
                                    eventModel.CountryName,
                                    new CountryDTO(eventModel.Country.Name,
                                                   eventModel.Country.Currency,
                                                   eventModel.Country.IsAvailableForUserRegistration
                                                   ),
                                    eventModel.EventTypeName,
                                    new EventTypeDTO(eventModel.EventType.Name)
                                    ) ;

            //EventDTO eventDTO = new()
            //{
            //    Id = eventModel.Id,
            //    Name = eventModel.Name,
            //    Description = eventModel.Description,
            //    MaxUsers = eventModel.MaxUsers,
            //    IsSoldOut= eventModel.IsSoldOut,
            //    Price = eventModel.Price,
            //    StartTime = eventModel.StartTime,
            //    EndTime = eventModel.EndTime,
            //    CountryName = eventModel.CountryName,
            //    EventTypeName = eventModel.EventTypeName
            //};

            return Ok(eventDTO);
        }

        return NotFound();
    }

    // POST api/<EventsController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventDTO eventDTO)
    {
        if(eventDTO is not null)
        {
            EventModel eventModel = new(eventDTO);
            //{
                //Name = eventDTO.Name,
                //Description = eventDTO.Description,
                //MaxUsers = eventDTO.MaxUsers,
                //Price = eventDTO.Price,
                //StartTime = eventDTO.StartTime,
                //EndTime = eventDTO.EndTime,
                //CountryName = eventDTO.CountryName,
                //EventTypeName = eventDTO.EventTypeName,
            //};

            await _unitOfWork.Events.Add(eventModel);

            return Ok();
        }

        return BadRequest();
    }

    // PUT api/<EventsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<EventsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool IsRemoved = await _unitOfWork.Events.RemoveByIdAsync(id);

        if (IsRemoved)
        {
            return Ok();
        }

        return NotFound();
    }
}
