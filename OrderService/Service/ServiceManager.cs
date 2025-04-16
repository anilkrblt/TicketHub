using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Repository.Contracts;
using OrderService.Service.Contracts;

namespace OrderService.Service
{

    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOrderService> _orderService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _orderService = new Lazy<IOrderService>(() =>
             new OrderService(repositoryManager));
        }
        public IOrderService OrderService => _orderService.Value;
    }

}