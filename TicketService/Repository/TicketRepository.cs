using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketService.Models;
using TicketService.Repository.Contracts;

namespace TicketService.Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void DeleteTicket(Ticket ticket) => Delete(ticket);

        public void CreateTicket(Ticket ticket) => Create(ticket);

        public async Task<Ticket> GetTicketAsync(int ticketId, bool trackChanges) =>
        await FindByCondition(c => c.TicketId.Equals(ticketId), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(c => c.Price).ToListAsync();
    }
}