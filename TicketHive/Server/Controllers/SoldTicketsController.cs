using Duende.IdentityServer.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Server.StaticMethods;
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
    [HttpGet("{id}")]
    public async Task<ActionResult<SoldTicketDTO>> Get(int id)
    {
        SoldTicketModel? soldTicketModel = await _unitOfWork.SoldTickets.GetOneByIdWithIncludesAsync(id);

        if (soldTicketModel is not null)
        {
            return Ok(TransformToDTO.FromSoldTicketModel(soldTicketModel));
        }

        return NotFound();
    }


    // GET api/<SoldTicketsController>/5
    [HttpGet("[action]/{username}")]
    public async Task<ActionResult<IEnumerable<SoldTicketDTO>?>> UserTickets(string username)
    {
        IEnumerable<SoldTicketModel>? soldTicketModels = await _unitOfWork.SoldTickets.GetUserTicketsAsync(username);

        if (soldTicketModels is not null)
        {
            IEnumerable<SoldTicketDTO> soldTicketDTOs = soldTicketModels.Select(TransformToDTO.FromSoldTicketModel);
        
            return Ok(soldTicketDTOs);
        }

        return NotFound();
    }

	// POST api/<SoldTicketsController>
	[HttpPost]
    public async Task<IActionResult> Post([FromBody] SoldTicketDTO soldTicketDTO)
    {
        if (soldTicketDTO is not null)
        {
            SoldTicketModel soldTicketModel = new(soldTicketDTO);

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