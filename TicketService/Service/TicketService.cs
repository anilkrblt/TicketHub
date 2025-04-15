using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Models;
using TicketService.Repository.Contracts;
using TicketService.Service.Contracts;
using TicketService.Shared.Dtos;

namespace TicketService.Service
{
    internal sealed class TicketService : ITicketService
    {

        private readonly IRepositoryManager _repositoryManager;


        public TicketService(IRepositoryManager repository)
        {
            _repositoryManager = repository;
        }

        public TicketForCreationDto CreateTicketAsync(TicketForCreationDto ticketForCreationDto)
        {
           throw new NotImplementedException();
        }

        public Task DeleteTicketAsync(int ticketId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketDto>> GetAllTicketsAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<TicketDto> GetTicketAsync(int ticketId, bool trackChanges)
        {
            var ticket = await _repositoryManager.Ticket.GetTicketAsync(ticketId, false);

            if (ticket is null){
                throw new NotImplementedException();
            }
            var ticketDto = new TicketDto();
            ticketDto.CreatedAt = ticket.CreatedAt;
            return ticketDto;
        }

        public Task UpdateTicketAsync(int ticketId, TicketForUpdateDto ticketForUpdateDto, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        Task<TicketForCreationDto> ITicketService.CreateTicketAsync(TicketForCreationDto ticketForCreationDto)
        {
            throw new NotImplementedException();
        }
    }
}