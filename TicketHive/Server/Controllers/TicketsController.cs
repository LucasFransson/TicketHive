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
    public async Task<ActionResult<IEnumerable<TicketDTO>>> Get()
    {
        IEnumerable<TicketDTO> tickets = (await _unitOfWork.Tickets.GetAllAsync()).Select(tm => new TicketDTO
        {
            Id = tm.Id,
            EventId = tm.EventId,
            Price = tm.Price,
            StartTime = tm.StartTime,
            EndTime = tm.EndTime
        });

        return Ok(tickets);
    }

    // GET api/<TicketsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDTO>> Get(int id)
    {
        TicketModel? ticketModel = await _unitOfWork.Tickets.GetByIdAsync(id);

        if (ticketModel is not null)
        {
            TicketDTO ticketDTO = new()
            {
                Id = ticketModel.Id,
                EventId = ticketModel.EventId,
                Price = ticketModel.Price,
                StartTime = ticketModel.StartTime,
                EndTime = ticketModel.EndTime
            };

            return Ok(ticketDTO);
        }

        return NotFound();
    }
    // POST api/<SoldTicketsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] List<TicketDTO> ticketDTOs)
    {
        IEnumerable<TicketModel> tickets = ticketDTOs.Select(tm => new TicketModel
        {
            EventId = tm.EventId,
            Price = tm.Price,
            StartTime = tm.StartTime,
            EndTime = tm.EndTime
        });

        if (tickets is not null)
        {
            await _unitOfWork.Tickets.AddRangeAsync(tickets);

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
    public void Delete(int id)
    {
    }
}
