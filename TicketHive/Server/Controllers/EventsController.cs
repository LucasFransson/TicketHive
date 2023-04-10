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
        IEnumerable<EventDTO>? events = (await _unitOfWork.Events.GetAllAsync()).Select(em => new EventDTO
        {
            Id = em.Id,
            Name = em.Name,
            Description = em.Description,
            MaxUsers = em.MaxUsers,
            IsSoldOut = em.IsSoldOut,
            Price = em.Price,
            StartTime = em.StartTime,
            EndTime = em.EndTime,
            CountryName = em.CountryName,
            EventTypeName = em.EventTypeName,
        });

        return Ok(events);
    }

    // GET api/<EventsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EventViewModel>> Get(int id)
    {
        EventModel? result = await _unitOfWork.Events.GetByIdAsync(id);
        
        if (result is not null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    // POST api/<EventsController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventDTO eventDTO)
    {
        if(eventDTO is not null)
        {
            EventModel eventModel = new()
            {
                Name = eventDTO.Name,
                Description = eventDTO.Description,
                MaxUsers = eventDTO.MaxUsers,
                Price = eventDTO.Price,
                StartTime = eventDTO.StartTime,
                EndTime = eventDTO.EndTime,
                CountryName = eventDTO.CountryName,
                EventTypeName = eventDTO.EventTypeName,
            };

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
        //bool IsRemoved = await _unitOfWork.Events.Remove(id);

        //if(IsRemoved)
        //{
        //    return Ok();
        //}

        return BadRequest();
    }
}
