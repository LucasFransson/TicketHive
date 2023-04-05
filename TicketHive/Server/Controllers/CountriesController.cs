using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CountriesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //GET: api/<CountriesController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryViewModel>>> Get()
    {
        return Ok(await _unitOfWork.Countries.GetAllAsync());
 
    }

    [HttpGet("{name}")]
    public Task<CountryViewModel> GetByName(string name)
    {
        return _unitOfWork.Countries.GetByName(name);
    }

    // POST api/<CountriesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CountriesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CountriesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
