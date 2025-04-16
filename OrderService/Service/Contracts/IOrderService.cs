using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Dtos;

namespace OrderService.Service.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync(bool trackChanges);
        Task<OrderDto> GetOrderAsync(int orderId, bool trackChanges);
        Task<OrderDto> CreateOrderAsync(OrderForCreationDto orderForCreationDto);
        Task DeleteOrderAsync(int orderId, bool trackChanges);
        Task UpdateOrderAsync(int orderId, OrderForUpdateDto orderForUpdateDto, bool trackChanges);

        
    }
}