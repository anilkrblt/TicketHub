using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Models;
using OrderService.Repository.Contracts;

namespace OrderService.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void DeleteOrder(Order order) => Delete(order);

        public void CreateOrder(Order order) => Create(order);

        public async Task<Order> GetOrderAsync(int orderId, bool trackChanges) =>
        await FindByCondition(c => c.TicketId.Equals(orderId), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Order>> GetOrdersAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(o => o.OrderDate).ToListAsync();
    }
}