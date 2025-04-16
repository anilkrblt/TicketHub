using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Dtos;
using OrderService.Models;
using OrderService.Repository.Contracts;
using OrderService.Service.Contracts;

namespace OrderService.Service
{
    public sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;


        public OrderService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderForCreationDto order)
        {
            var orderEntity = new Order
            {
                OrderDate = order.OrderDate,
                Status = order.Status,
                TicketId = order.TicketId,
                UserId = order.UserId
            };

            _repository.Order.CreateOrder(orderEntity);
            await _repository.SaveAsync();

            var orderToReturn = new OrderDto
            {
                OrderId = orderEntity.OrderId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TicketId = order.TicketId,
                UserId = order.UserId

            };


            return orderToReturn;
        }

        public async Task DeleteOrderAsync(int orderId, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            if (order is null)
            {
                throw new NotImplementedException();
            }
            _repository.Order.DeleteOrder(order);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(bool trackChanges)
        {
            var orders = await _repository.Order.GetOrdersAsync(trackChanges);
            var dto = orders.Select(order => new OrderDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TicketId = order.TicketId,
                UserId = order.UserId

            }).ToList();

            return dto;
        }

        public async Task<OrderDto> GetOrderAsync(int orderId, bool trackChanges)
        {

            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);

            if (order is null)
            {
                throw new NotImplementedException();
            }
            var orderDto = new OrderDto();

            orderDto.OrderId = order.OrderId;
            orderDto.OrderDate = order.OrderDate;
            orderDto.Status = order.Status;
            orderDto.TicketId = order.TicketId;
            orderDto.UserId = order.UserId;


            return orderDto;
        }

        public async Task UpdateOrderAsync(int orderId, OrderForUpdateDto orderForUpdateDto, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            order.OrderDate = orderForUpdateDto.OrderDate;
            order.Status = orderForUpdateDto.Status;
            order.TicketId = orderForUpdateDto.TicketId;
            order.UserId = orderForUpdateDto.UserId;

            await _repository.SaveAsync();
        }
    }
}