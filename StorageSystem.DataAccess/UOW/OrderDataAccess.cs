using Microsoft.EntityFrameworkCore;
using StorageSystem.Application.Contracts.DataAccess;
using StorageSystem.DataAccess.UOW.Base;
using StorageSystem.Domain.Entities;
using StorageSystem.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess.UOW
{
    public class OrderDataAccess : GenericDataAccess<Order>, IOrderDataAccess
    {
        public OrderDataAccess(IApplicationDbContext context) : base(context)
        {
        }

        public async Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
        {
            await InsertAsync(order, cancellationToken);
        }

        public async Task CreateOrderRangeAsync(List<Order> orders, CancellationToken cancellationToken = default)
        {
            await _context.Orders.AddRangeAsync(orders, cancellationToken);
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
        }

        public void DeleteOrderRange(List<Order> orders)
        {
            _context.Orders.RemoveRange(orders);
        }

        public Task<IEnumerable<Order>> FindAllOrdersById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrders(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrders(bool trackingReference, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrderUnpaidByCustomerId(Guid customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId && o.StatusOrder == Domain.Enums.StatusOrder.UNPAID).ToListAsync();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }

        public void UpdateOrderRange(List<Order> orders)
        {
            _context.Orders.UpdateRange(orders);
        }
    }
}
