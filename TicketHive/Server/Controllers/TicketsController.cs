using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Server.StaticMethods;
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
        IEnumerable<TicketDTO>? tickets = (await _unitOfWork.Tickets.GetAllWithIncludesAsync())?.Select(TransformToDTO.FromTicketModel);

        return Ok(tickets);
    }

    // GET api/<TicketsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDTO>> Get(int id)
    {
        TicketModel? ticketModel = await _unitOfWork.Tickets.GetOneByIdWithIncludesAsync(id);

        if (ticketModel is not null)
        {
            return Ok(TransformToDTO.FromTicketModel(ticketModel));
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
}
