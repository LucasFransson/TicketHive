using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Implementations;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Shared.DTO;
using TicketHive.Shared.DTOs;
using TicketHive.Shared.ViewModels;


namespace TicketHive.Bll.Services.Managers
{
    public class CheckOutManager
    {
        private readonly IUnitOfService _unitOfService;
        public CheckOutManager(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }

        public async Task<List<TicketViewModel>> GetTickets(params CartItemViewModel[] items)
        {
            List<TicketViewModel> tickets = new();
            foreach (var item in items)
            {
                TicketViewModel newTicket = await _unitOfService.TicketService.GetByIdAsync(item.Id);
                tickets.Add(newTicket);
            }

            return tickets;
        }
        public async Task<List<TicketViewModel>> GetTickets(List<CartItemViewModel> items)
        {
            
            
            List<TicketViewModel> tickets = new();
            foreach (var item in items)
            {
                //TicketViewModel newTicket = await _unitOfService.TicketService.GetByEventId(item.Id);
               
                //tickets.Add(newTicket);
            }

            return tickets;
        }
        public decimal GetTotalCost(params CartItemViewModel[] items)
		{
			decimal totalCost = 0;
			foreach (var item in items)
			{
				totalCost += item.Price;
			}

			if (totalCost <= 0)
			{
				return 0;
			}

			return totalCost;
		}

        public decimal GetTotalCost(List<CartItemViewModel> items)
        {
            decimal totalCost = 0;
            foreach (var item in items)
            {
                totalCost += item.Price;
            }

            if (totalCost <= 0)
            {
                return 0;
            }

            return totalCost;
        }
        public async Task CheckOut(List<TicketViewModel> tickets)
		{
			List<SoldTicketViewModel> usersTickets = new();

			// Set the properties from the ticket to the SoldTicket
			foreach (var ticket in tickets)
			{
				SoldTicketViewModel soldTicket = new(ticket, "Username");    // Placeholder string for This.loggedin username
				usersTickets.Add(soldTicket);
			}
            await _unitOfService.SoldTicketService.AddRangeAsync(usersTickets);

			// Removes all the tickets from the db
			foreach (var ticket in tickets)
			{
				await _unitOfService.TicketService.RemoveRange(tickets); // Await for some confirmation? 
			}
            
            
		}
		public void ConfirmBuy()
		{

		}
		public void CancelBuy() { }
	}
}
