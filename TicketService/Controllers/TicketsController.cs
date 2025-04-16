using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketService.Models;
using TicketService.Service.Contracts;
using TicketService.Shared.Dtos;

namespace TicketService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TicketsController(IServiceManager service) => _service = service;


        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _service.TicketService.GetAllTicketsAsync(trackChanges: false);
            return Ok(tickets);
        }


        [HttpGet("{id:int}", Name = "TicketById")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _service.TicketService.GetTicketAsync(id, trackChanges: false);
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketForCreationDto ticket)
        {

            var createdTicket = await _service.TicketService.CreateTicketAsync(ticket);

            return CreatedAtRoute("TicketById", new { id = createdTicket.TicketId },
           createdTicket);
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _service.TicketService.DeleteTicketAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketForUpdateDto ticket)
        {

            await _service.TicketService.UpdateTicketAsync(id, ticket, trackChanges: true);

            return NoContent();
        }
    }
}