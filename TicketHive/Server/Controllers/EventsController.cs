using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
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
    public async Task<ActionResult<IEnumerable<EventViewModel>>> Get()
    {
        return Ok(await _unitOfWork.Events.GetAllAsync());
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
    public async Task<IActionResult> Post([FromBody] EventViewModel eventViewModel)
    {
        if(eventViewModel is not null)
        {
            //await _unitOfWork.Events.Add(eventViewModel);
            //await _unitOfWork.Complete();
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
