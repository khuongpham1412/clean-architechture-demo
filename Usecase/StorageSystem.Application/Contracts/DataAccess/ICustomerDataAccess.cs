using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Contracts.DataAccess
{
    public interface ICustomerDataAccess : IGenericDataAccess<Customer>
    {
        Task CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);

        Task CreateCustomerRangeAsync(List<Customer> customers, CancellationToken cancellationToken = default);

        void UpdateCustomer(Customer customer);

        void UpdateCustomerRange(List<Customer> customers);

        void DeleteCustomer(Customer customer);

        void DeleteCustomerRange(List<Customer> customers);

        Task<IEnumerable<Customer>> GetAllCustomers(FilterCustomer filter, CancellationToken cancellationToken = default);

        Task<IEnumerable<Customer>> GetAllCustomers(FilterCustomer filter, bool trackingReference, CancellationToken cancellationToken = default);

        Task<Customer> FindCustomerById(Guid Id);

        Task<Customer> FindCustomerByPhoneNumber(string phone);

        int GetTotalCustomers(string keyword = null);
    }
}