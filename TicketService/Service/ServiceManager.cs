using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Repository.Contracts;
using TicketService.Service.Contracts;

namespace TicketService.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITicketService> _ticketService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _ticketService = new Lazy<ITicketService>(() =>
             new TicketService(repositoryManager));
        }
        public ITicketService TicketService => _ticketService.Value;
    }
}