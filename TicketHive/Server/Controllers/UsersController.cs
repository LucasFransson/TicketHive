using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Implementations;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHive.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class usersController : ControllerBase
{
	private readonly SignInManager<UserModel> _signInManager;
	private readonly AppDbContext _appDbContext;
    private readonly IUnitOfWork _unitOfWork;

    public IUnitOfWork UnitOfWork { get; }

	public usersController(SignInManager<UserModel> signInManager, AppDbContext appDbContext, IUnitOfWork unitOfWork)
	{
		_signInManager = signInManager;
		_appDbContext = appDbContext;
		_unitOfWork = unitOfWork;

	}

    // GET: api/<usersController>
    [HttpGet]
	public IEnumerable<string> Get()
	{
		return new string[] { "value1", "value2" };
	}

	// GET api/<usersController>/5
	[HttpGet("{username}")]
	public async Task<ActionResult<UserDTO>?> Get(string username)
	{
		UserModel? user = await _signInManager.UserManager.FindByNameAsync(username);

		var test = user.CountryName;

		CountryModel? country = await _unitOfWork.Countries.GetByNameAsync(test);

		if(user is not null)
		{
			//CountryDTO countryDTO = new(country.Name, country.Currency, country.IsAvailableForUserRegistration);
			UserDTO userDTO = new(country.Name, country.Currency);

			return Ok(userDTO);
		}

		return NotFound();
	}

	// POST api/<usersController>
	[HttpPost]
	public void Post([FromBody] string value)
	{
	}

	// PUT api/<usersController>/5
	[HttpPut("{id}")]
	public void Put(int id, [FromBody] string value)
	{
	}

	// DELETE api/<usersController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
	}
}
