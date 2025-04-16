using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Dtos
{
    public record OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; }
    }
    public record OrderForCreationDto
    {
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; }
    }

    public record OrderForUpdateDto
    {
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; }

    }
}