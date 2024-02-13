using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface IOrderDataAccess
    {
        Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default);

        Task CreateOrderRangeAsync(List<Order> orders, CancellationToken cancellationToken = default);

        void UpdateOrder(Order order);

        void UpdateOrderRange(List<Order> orders);

        void DeleteOrder(Order order);

        void DeleteOrderRange(List<Order> orders);

        Task<IEnumerable<Order>> GetAllOrders(CancellationToken cancellationToken = default);

        Task<IEnumerable<Order>> GetAllOrders(bool trackingReference, CancellationToken cancellationToken = default);

        Task<IEnumerable<Order>> FindAllOrdersById(Guid Id);

        Task<IEnumerable<Order>> GetOrderUnpaidByCustomerId(Guid customerId);
    }
}
