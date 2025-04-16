using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Repository.Contracts
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync(bool trackChanges);
        Task<Ticket> GetTicketAsync(int ticketId, bool trackChanges);
        void CreateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}