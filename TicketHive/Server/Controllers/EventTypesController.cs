﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHive.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventTypesController : ControllerBase
{
    // GET: api/<EventTypesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<EventTypesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
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
