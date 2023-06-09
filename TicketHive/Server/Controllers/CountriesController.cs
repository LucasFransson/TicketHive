﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

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
    public async Task<ActionResult<IEnumerable<CountryDTO>>> Get()
    {
        IEnumerable<CountryDTO> countries = (await _unitOfWork.Countries.GetAllAsync())
            .Select(cm => new CountryDTO(cm.Name, cm.Currency, cm.IsAvailableForUserRegistration));

        return Ok(countries);
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<CountryDTO>> Get(string name)
    {
        CountryModel? countryModel = await _unitOfWork.Countries.GetByNameAsync(name);

        if (countryModel is not null)
        {
            CountryDTO countryDTO = new(countryModel.Name, countryModel.Currency, countryModel.IsAvailableForUserRegistration);

            return Ok(countryDTO);
        }

        return NotFound();
    }

    // POST api/<CountriesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CountryDTO countryDTO)
    {
        if (countryDTO is not null)
        {
            CountryModel countryModel = new(countryDTO);

            await _unitOfWork.Countries.AddAsync(countryModel);

            return Ok();
        }

        return BadRequest();
    }

    // PUT api/<CountriesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CountriesController>/5
    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        bool IsRemoved = await _unitOfWork.Countries.RemoveByNameAsync(name);

        if (IsRemoved)
        {
            return Ok();
        }

        return NotFound();
    }
}
