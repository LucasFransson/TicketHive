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
    private readonly UserManager<UserModel> _userManager;

    public IUnitOfWork UnitOfWork { get; }

	public usersController(SignInManager<UserModel> signInManager, AppDbContext appDbContext, IUnitOfWork unitOfWork, UserManager<UserModel> userManager)
	{
		_signInManager = signInManager;
		_appDbContext = appDbContext;
		_unitOfWork = unitOfWork;
		_userManager = userManager;

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
	public async Task<ActionResult> Put(string id, [FromBody] UserDTO userDto)
	{
		var user = await _userManager.GetUserAsync(HttpContext.User);

		ArgumentNullException.ThrowIfNull(user);

		if (user.Id != id)
		{
			return new UnauthorizedResult();
		}

		if (string.IsNullOrEmpty(userDto.CurrentPassword) == false && string.IsNullOrEmpty(userDto.NewPassword) == false)
		{
			var result = await _userManager.ChangePasswordAsync(user, userDto.CurrentPassword, userDto.NewPassword);

			if (result.Succeeded == false)
			{
				return new BadRequestObjectResult(result.Errors);
			}
		}
		return new OkResult();
	}

	// DELETE api/<usersController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
	}
}
