using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Shared.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHive.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventTypesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public EventTypesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/<EventTypesController>
    [HttpGet]
    public async Task<ActionResult<List<EventTypeViewModel>>> Get()
    {
        return Ok(await _unitOfWork.EventTypes.GetAllAsync());
    }

    // GET api/<EventTypesController>/5
    [HttpGet("{name}")]
    public async Task<ActionResult<EventTypeViewModel>> Get(string name)
    {
        EventTypeViewModel result = await _unitOfWork.EventTypes.GetByNameAsync(name);

        if (result is not null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    // POST api/<EventTypesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<EventTypesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<EventTypesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
