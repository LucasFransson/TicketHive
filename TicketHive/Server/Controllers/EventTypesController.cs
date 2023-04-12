using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;
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
    public async Task<ActionResult<IEnumerable<EventTypeDTO>>> Get()
    {
        IEnumerable<EventTypeDTO> eventTypeDTOs = (await _unitOfWork.EventTypes.GetAllAsync()).Select(etm => new EventTypeDTO(etm.Name));

        return Ok(eventTypeDTOs);
    }

    // GET api/<EventTypesController>/5
    [HttpGet("{name}")]
    public async Task<ActionResult<EventTypeDTO>> Get(string name)
    {
        EventTypeModel? eventTypeModel = await _unitOfWork.EventTypes.GetByNameAsync(name);

        if (eventTypeModel is not null)
        {
            EventTypeDTO eventTypeDTO = new EventTypeDTO(eventTypeModel.Name);

            return Ok(eventTypeDTO);
        }

        return NotFound();
    }

    // POST api/<EventTypesController>
    [HttpPost]
    public IActionResult Post([FromBody] EventTypeDTO eventTypeDTO)
    {
        if(eventTypeDTO is not null)
        {
            EventTypeModel eventTypeModel = new(eventTypeDTO);
            
            _unitOfWork.EventTypes.Add(eventTypeModel);

            return Ok();
        }

        return BadRequest();
    }

    // PUT api/<EventTypesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<EventTypesController>/5
    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        bool IsRemoved = await _unitOfWork.EventTypes.RemoveByNameAsync(name);

        if (IsRemoved)
        {
            return Ok();
        }

        return NotFound();
    }
}
