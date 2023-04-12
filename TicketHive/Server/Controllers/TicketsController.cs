using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHive.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/<TicketsController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketDTO>?>> Get()
    {
        IEnumerable<TicketDTO>? tickets = (await _unitOfWork.Tickets.GetAllWithIncludesAsync())?.Select(CreateDTO);

        return Ok(tickets);
    }

    // GET api/<TicketsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDTO>> Get(int id)
    {
        TicketModel? ticketModel = await _unitOfWork.Tickets.GetOneByIdWithIncludesAsync(id);

        if (ticketModel is not null)
        {
            return Ok(CreateDTO(ticketModel));
        }

        return NotFound();
    }
    // POST api/<SoldTicketsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] List<TicketDTO> ticketDTOs)
    {
        IEnumerable<TicketModel> ticketModels = ticketDTOs.Select(t => new TicketModel(t));

        if (ticketModels is not null)
        {
            await _unitOfWork.Tickets.AddRangeAsync(ticketModels);

            return Ok();
        }

        return BadRequest();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {

    }

    // DELETE api/<TicketsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool IsRemoved = await _unitOfWork.Tickets.RemoveByIdAsync(id);

        if (IsRemoved)
        {
            return Ok();
        }

        return NotFound();
    }

        private TicketDTO CreateDTO(TicketModel ticketModel)
    {
        EventTypeDTO eventTypeDTO = new(ticketModel.Event.EventType.Name);

        CountryDTO countryDTO = new(ticketModel.Event.Country.Name, ticketModel.Event.Country.Currency, ticketModel.Event.Country.IsAvailableForUserRegistration);

        EventDTO eventDTO = new(ticketModel.Event.Id, ticketModel.Event.Name, ticketModel.Event.Description, ticketModel.Event.ImageString, ticketModel.Event.MaxUsers, ticketModel.Event.TicketsLeft, ticketModel.Event.Price, ticketModel.Event.StartTime, ticketModel.Event.EndTime, ticketModel.Event.CountryName, countryDTO, ticketModel.Event.EventTypeName, eventTypeDTO);

        TicketDTO ticketDTO = new(ticketModel.Id, ticketModel.EventId, eventDTO, ticketModel.Price, ticketModel.StartTime, ticketModel.EndTime);

        return ticketDTO;
    }
}
