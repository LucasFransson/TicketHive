using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.DTOs;

namespace TicketHive.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldTicketsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public async Task<SoldTicketDto> GetByEntity(SoldTicketModel model)
        {
            return new SoldTicketDto
            {
                Id = model.Id,
                //Event = model.Event,
                Username = model.Username,
                Price = model.Price,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };
        }


        [HttpGet] // Not in use, for  syntax test purposes only!
        public async Task<List<SoldTicketDto>> GetAllSoldTicketsAsync()
        {
            var soldTickets = await _unitOfWork.SoldTickets.GetAllAsync();
            var soldTicketDtos = new List<SoldTicketDto>();

            foreach (var soldTicket in soldTickets)
            {
                var eventModel = await _unitOfWork.Events.GetByIdAsync(soldTicket.Event.Id);
                var countryModel = await _unitOfWork.Countries.GetByName(eventModel.CountryName);

                var eventDto = new EventViewModel
                {
                    Name = eventModel.Name,
                    MaxUsers = eventModel.MaxUsers,
                    Price = eventModel.Price,
                    Country = new CountryDTO
                    {
                        Name = countryModel.Name,
                        Currency = countryModel.Currency,
                        IsAvailableForUserRegistration = countryModel.IsAvailableForUserRegistration
                    }
                };

                var soldTicketDto = new SoldTicketDto
                {
                    Id = soldTicket.Id,
                    Event = eventDto,
                    Username = soldTicket.Username,
                    Price = soldTicket.Price,
                    StartTime = soldTicket.StartTime,
                    EndTime = soldTicket.EndTime
                };

                soldTicketDtos.Add(soldTicketDto);
            }

            return soldTicketDtos;
        }
    }
}
