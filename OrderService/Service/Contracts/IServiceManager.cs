using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Service.Contracts
{
    public interface IServiceManager
    {
        IOrderService OrderService { get; }

    }
}