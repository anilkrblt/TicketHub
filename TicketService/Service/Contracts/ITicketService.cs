using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Models;
using TicketService.Shared.Dtos;

namespace TicketService.Service.Contracts
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync(bool trackChanges);
        Task<TicketDto> GetTicketAsync(int ticketId, bool trackChanges);
        Task<TicketDto> CreateTicketAsync(TicketForCreationDto ticketForCreationDto);
        Task DeleteTicketAsync(int ticketId, bool trackChanges);
        Task UpdateTicketAsync(int ticketId, TicketForUpdateDto ticketForUpdateDto, bool trackChanges);

    }
}