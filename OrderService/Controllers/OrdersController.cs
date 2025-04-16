using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Models;
using OrderService.Service.Contracts;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OrdersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _service.OrderService.GetAllOrdersAsync(trackChanges: false);
            return Ok(orders);
        }


        [HttpGet("{id:int}", Name = "OrderById")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var order = await _service.OrderService.GetOrderAsync(id, trackChanges: false);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] OrderForCreationDto order)
        {

            var createdOrder = await _service.OrderService.CreateOrderAsync(order);

            return CreatedAtRoute("OrderById", new { id = createdOrder.OrderId },
           createdOrder);
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _service.OrderService.DeleteOrderAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderForUpdateDto order)
        {

            await _service.OrderService.UpdateOrderAsync(id, order, trackChanges: true);

            return NoContent();
        }
    }

}