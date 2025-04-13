using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Repository.Contracts;

namespace OrderService.Repository
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IOrderRepository> _orderRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        }

        public IOrderRepository Ticket => _orderRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        
    }
}