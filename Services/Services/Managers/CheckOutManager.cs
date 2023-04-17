using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Implementations;
using TicketHive.Bll.Services.Interfaces;
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
                TicketViewModel newTicket = await _unitOfService.TicketService.GetByIdAsync(item.Id);
               
                tickets.Add(newTicket);
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
        public async Task CheckOut(List<TicketViewModel> tickets, string username)
		{
			List<SoldTicketViewModel> usersTickets = new();

			// Set the properties from the ticket to the SoldTicket
			foreach (var ticket in tickets)
			{
				SoldTicketViewModel soldTicket = new(ticket, username);    
				usersTickets.Add(soldTicket);
			}

            foreach(var t in usersTickets)
            {
                await _unitOfService.SoldTicketService.AddAsync(t);
            }

            // Removes all the tickets from the db
            foreach (var ticket in tickets)
            {
                _unitOfService.TicketService.Remove(ticket.Id);
            }
        }

        public List<string> ReturnReciept(List<TicketViewModel> userTickets)
        {
            List<string> orderedTickets = new();
            foreach(var ticket in userTickets)
            {
                orderedTickets.Add(ticket.Event.Name);
            }
            return orderedTickets;
        }
        
		public void ConfirmBuy()
		{

		}
		public void CancelBuy() { }
	}
}
