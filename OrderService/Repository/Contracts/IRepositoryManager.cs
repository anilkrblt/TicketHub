using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IOrderRepository Ticket { get; }

        Task SaveAsync();

    }
}