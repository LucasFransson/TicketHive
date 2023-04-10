using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHive.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    // GET: api/<TicketsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<TicketsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<TicketsController>
    //[HttpPost]
    //public async Task<ActionResult> Post()
    //{
        ////if (soldTicketDTO is not null)
        ////{
        //    TicketModel TicketModel = new()
        //    {
        //        //Id = soldTicketDTO.Id,
        //        ////EventId = soldTicketDTO.EventId,
        //        //Username = soldTicketDTO.Username,
        //        //Price = soldTicketDTO.Price,
        //        //StartTime = soldTicketDTO.StartTime,
        //        //EndTime = soldTicketDTO.EndTime,
        //    };

        //    await _unitOfWork.Tickets.Add(soldTicketModel);

        //    return Ok();
        ////}

        //return BadRequest();

        // PUT api/<TicketsController>/5
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
