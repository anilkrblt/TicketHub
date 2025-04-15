using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Repository.Contracts;

namespace TicketService.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ITicketRepository> _ticketRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _ticketRepository = new Lazy<ITicketRepository>(() => new TicketRepository(repositoryContext));
        }

        public ITicketRepository Ticket => _ticketRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        
    }
}