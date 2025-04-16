using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Repository.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync(bool trackChanges);
        Task<Order> GetOrderAsync(int orderId, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
        
    }
}