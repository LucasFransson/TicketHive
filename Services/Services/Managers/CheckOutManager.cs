using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Bll.Services.Implementations;
using TicketHive.Shared.DTOs;
using TicketHive.Shared.ViewModels;


namespace TicketHive.Bll.Services.Managers
{
    public class CheckOutManager
    {
        private readonly UnitOfService _unitOfService;
        public CheckOutManager(UnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }

        public void ConfirmBuy()
        {

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
        public void CheckOut() { }
        public void CancelBuy() { }
        public decimal GetTotalCost(params CartItemViewModel[] items)
        {
            decimal totalCost = 0;
            foreach (var item in items)
            {
                totalCost += item.Price;
            }

            if(totalCost <= 0)
            {
                return 0;
            }

            return totalCost;
        }

    }
}
