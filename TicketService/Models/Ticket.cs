using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace TicketService.Models
{
    public class Ticket
    {
        [Key]
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
}