using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Shared.ViewModels;
public class CartItemViewModel
{
    public int EventId { get; set; }
    public string? EventName { get; set; }
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Quantity { get; set; }
}
