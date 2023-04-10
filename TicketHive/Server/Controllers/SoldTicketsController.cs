using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHive.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SoldTicketsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public SoldTicketsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/<SoldTicketsController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SoldTicketDTO>>> Get()
    {
        IEnumerable<SoldTicketDTO> soldTickets = (await _unitOfWork.SoldTickets.GetAllAsync()).Select(stm => new SoldTicketDTO
        {
            Id = stm.Id,
            EventId = stm.EventId,
            Username = stm.Username,
            Price = stm.Price,
            StartTime = stm.StartTime,
            EndTime = stm.EndTime,
        });

        return Ok(soldTickets);
    }
    // GET api/<SoldTicketsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SoldTicketDTO>> Get(int id)
    {
        SoldTicketModel? soldTicketModel = await _unitOfWork.SoldTickets.GetByIdAsync(id);

        if (soldTicketModel is not null)
        {
            SoldTicketDTO soldTicketDTO = new()
            {
                Id = soldTicketModel.Id,
                EventId = soldTicketModel.EventId,
                Username = soldTicketModel.Username,
                Price = soldTicketModel.Price,
                StartTime = soldTicketModel.StartTime,
                EndTime = soldTicketModel.EndTime
            };

            return Ok(soldTicketDTO);
        }

        return NotFound();
    }

    // POST api/<SoldTicketsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SoldTicketDTO soldTicketDTO)
    {
        if (soldTicketDTO is not null)
        {
            SoldTicketModel soldTicketModel = new()
            {
                Id = soldTicketDTO.Id,
                EventId = soldTicketDTO.EventId,
                Username = soldTicketDTO.Username,
                Price = soldTicketDTO.Price,
                StartTime = soldTicketDTO.StartTime,
                EndTime = soldTicketDTO.EndTime
            };

            await _unitOfWork.SoldTickets.Add(soldTicketModel);

            return Ok();
        }

        return BadRequest();
    }

    // PUT api/<SoldTicketsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<SoldTicketsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
    
}