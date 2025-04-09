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

        [ForeignKey(nameof(EventDetails))]
        public int EventId { get; set; }

        public required EventDetails EventDetails { get; set; }

        // event_id INT -- refers to Event_Details.id

    }
}