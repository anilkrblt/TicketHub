using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly OrderDbContext _context;
        private readonly HttpClient _httpClient;

        public OrdersController(OrderDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
        }

        // 1. Yeni sipariş oluştur
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            order.Status = OrderStatus.Pending;
            order.OrderDate = DateTime.UtcNow;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // 1. Payment servisine ödeme isteği gönder
            var paymentRequest = new
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                TicketId = order.TicketId,
                Amount = 100 // örnek sabit ücret, ticket servisinden alınabilir
            };

            var response = await _httpClient.PostAsJsonAsync("http://paymentservice/api/payments", paymentRequest);

            if (response.IsSuccessStatusCode)
            {
                order.Status = OrderStatus.Completed;
            }
            else
            {
                order.Status = OrderStatus.Cancelled;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }

        // Sipariş durumunu güncelle
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // sipariş geçmişini listele
        [HttpGet("user/userId")]
        public async Task<IActionResult> GetOrderByUser(int userId)
        {
            var orders = await _context.Orders
            .Where(x => x.UserId == userId)
            .ToListAsync();
            return Ok(orders);
        }
        // Sipariş detaylarını getir ticket ve user bilgileri ile
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            // Simulated TicketService ve UserService çağrısı (url'leri örnek)
            var userResponse = await _httpClient.GetStringAsync($"http://userservice/api/users/{order.UserId}");
            var ticketResponse = await _httpClient.GetStringAsync($"http://ticketservice/api/tickets/{order.TicketId}");

            var user = JsonSerializer.Deserialize<object>(userResponse); // gerçek modelle değiştir
            var ticket = JsonSerializer.Deserialize<object>(ticketResponse); // gerçek modelle değiştir

            return Ok(new
            {
                Order = order,
                User = user,
                Ticket = ticket
            });

        }
    }

}