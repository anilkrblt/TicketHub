using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Repository.Contracts
{
    public interface IRepositoryManager
    {
        ITicketRepository Ticket { get; }

        Task SaveAsync();

    }
}