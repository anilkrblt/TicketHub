using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Models
{
    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }
        public string? Name { get; set; }
        public string? Organizer { get; set; }
        public string? Location { get; set; }
        public DateTime EventDate { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }

    }
}