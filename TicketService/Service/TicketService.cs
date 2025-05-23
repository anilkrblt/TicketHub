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

        private readonly IRepositoryManager _repository;

        public TicketService(IRepositoryManager repository)
        {
            _repository = repository;

        }

        public async Task<TicketDto> CreateTicketAsync(TicketForCreationDto ticket)
        {
            var ticketEntity = new Ticket
            {
                CreatedAt = DateTime.Now,
                Price = ticket.Price,
                SeatNumber = ticket.SeatNumber,
                IsSold = ticket.IsSold,
                EventDate = ticket.EventDate,
                Location = ticket.Location,
                Name = ticket.Name,
                Organizer = ticket.Organizer,
            };

            _repository.Ticket.CreateTicket(ticketEntity);
            await _repository.SaveAsync();

            var ticketToReturn = new TicketDto
            {
                TicketId = ticketEntity.TicketId,
                CreatedAt = ticketEntity.CreatedAt,
                Price = ticket.Price,
                SeatNumber = ticket.SeatNumber,
                IsSold = ticket.IsSold,
                EventDate = ticket.EventDate,
                Location = ticket.Location,
                Name = ticket.Name,
                Organizer = ticket.Organizer,
            };


            return ticketToReturn;

        }

        public async Task DeleteTicketAsync(int ticketId, bool trackChanges)
        {

            var ticket = await _repository.Ticket.GetTicketAsync(ticketId, true);
            if (ticket is null)
            {
                throw new NotImplementedException();
            }
            _repository.Ticket.DeleteTicket(ticket);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync(bool trackChanges)
        {
            var tickets = await _repository.Ticket.GetTicketsAsync(trackChanges);
            var dto = tickets.Select(ticket => new TicketDto
            {
                CreatedAt = ticket.CreatedAt,
                IsSold = ticket.IsSold,
                Price = ticket.Price,
                SeatNumber = ticket.SeatNumber,
                TicketId = ticket.TicketId,
                EventDate = ticket.EventDate,
                Location = ticket.Location,
                Name = ticket.Name,
                Organizer = ticket.Organizer,

            }).ToList();

            return dto;
        }

        public async Task<TicketDto> GetTicketAsync(int ticketId, bool trackChanges)
        {
            var ticket = await _repository.Ticket.GetTicketAsync(ticketId, false);

            if (ticket is null)
            {
                throw new NotImplementedException();
            }
            var ticketDto = new TicketDto();
            ticketDto.CreatedAt = ticket.CreatedAt;
            ticketDto.IsSold = ticket.IsSold;
            ticketDto.Price = ticket.Price;
            ticketDto.SeatNumber = ticket.SeatNumber;
            ticketDto.TicketId = ticket.TicketId;
            ticketDto.EventDate = ticket.EventDate;
            ticketDto.Location = ticket.Location;
            ticketDto.Name = ticket.Name;
            ticketDto.Organizer = ticket.Organizer;


            return ticketDto;
        }

        public async Task UpdateTicketAsync(int ticketId, TicketForUpdateDto ticketForUpdateDto, bool trackChanges)
        {
            var ticket = await _repository.Ticket.GetTicketAsync(ticketId, trackChanges);
            ticket.CreatedAt = ticket.CreatedAt;
            ticket.IsSold = ticketForUpdateDto.IsSold;
            ticket.Price = ticketForUpdateDto.Price;
            ticket.SeatNumber = ticketForUpdateDto.SeatNumber;
            ticket.EventDate = ticketForUpdateDto.EventDate;
            ticket.Location = ticketForUpdateDto.Location;
            ticket.Name = ticketForUpdateDto.Name;
            ticket.Organizer = ticketForUpdateDto.Organizer;


            await _repository.SaveAsync();

        }

    }
}