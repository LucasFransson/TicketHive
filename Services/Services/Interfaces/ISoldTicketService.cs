using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Bll.Services.Interfaces
{
    public interface ISoldTicketService : IService<SoldTicketViewModel>
    {
        Task<IEnumerable<SoldTicketViewModel>> GetAllByNameAsync(string name);
    }
}
