using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Service.Contracts
{
    public interface IServiceManager
    {
        ITicketService TicketService { get; }

    }
}