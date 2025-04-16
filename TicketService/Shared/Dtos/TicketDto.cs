using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Shared.Dtos
{
    public record TicketDto
    {
        public int TicketId { get; set; }
        public decimal Price { get; set; }
        public string? SeatNumber { get; set; }
        public bool IsSold { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Name { get; set; }
        public string? Organizer { get; set; }
        public string? Location { get; set; }
        public DateTime EventDate { get; set; }

    }
    public record TicketForCreationDto
    {
        public decimal Price { get; set; }
        public string? SeatNumber { get; set; }
        public bool IsSold { get; set; }
        public string? Name { get; set; }
        public string? Organizer { get; set; }
        public string? Location { get; set; }
        public DateTime EventDate { get; set; }
    }

    public record TicketForUpdateDto
    {
        public decimal Price { get; set; }
        public string? SeatNumber { get; set; }
        public bool IsSold { get; set; }
        public string? Name { get; set; }
        public string? Organizer { get; set; }
        public string? Location { get; set; }
        public DateTime EventDate { get; set; }

    }
}
