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
    public async Task<IEnumerable<EventTypeViewModel>> Get()
    {
        return await _unitOfWork.EventTypes.GetAllAsync();
    }

    // GET api/<EventTypesController>/5
    [HttpGet("{name}")]
    public async Task<EventTypeViewModel> Get(string name)
    {
        return await _unitOfWork.EventTypes.GetByNameAsync(name);
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
