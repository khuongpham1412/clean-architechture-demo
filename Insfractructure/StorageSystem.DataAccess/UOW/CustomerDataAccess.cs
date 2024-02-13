using Microsoft.EntityFrameworkCore;
using StorageSystem.Application.Contracts.DataAccess;
using StorageSystem.Application.Models.Bases;
using StorageSystem.DataAccess.UOW.Base;
using StorageSystem.Domain.Entities;
using StorageSystem.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess.UOW;

public class CustomerDataAccess : GenericDataAccess<Customer>, ICustomerDataAccess
{
    public CustomerDataAccess(IApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        await InsertAsync(customer, cancellationToken);
    }

    public async Task CreateCustomerRangeAsync(List<Customer> customers, CancellationToken cancellationToken = default)
    {
        await _context.Customers.AddRangeAsync(customers, cancellationToken);
    }

    public void DeleteCustomer(Customer customer)
    {
        customer.IsDeleted = true;
        _context.Customers.Update(customer);
    }

    public void DeleteCustomerRange(List<Customer> customers)
    {
        _context.Customers.RemoveRange(customers);
    }

    public async Task<Customer> FindCustomerById(Guid Id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == Id);
    }

    public async Task<Customer> FindCustomerByPhoneNumber(string phone)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Phone == phone);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers(FilterCustomer filter, CancellationToken cancellationToken = default)
    {
        return await _context.Customers
            .Where(p => string.IsNullOrEmpty(filter.Keyword) || p.Name.ToLower().Contains(filter.Keyword.ToLower()) 
            || p.Phone.ToLower().Contains(filter.Keyword.ToLower()))
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers(FilterCustomer filter, bool trackingReference, CancellationToken cancellationToken = default)
    {
        var list = await _context.Customers
            .Where(p => (string.IsNullOrEmpty(filter.Keyword) || p.Name.ToLower().Contains(filter.Keyword.ToLower()) || p.Phone.ToLower().Contains(filter.Keyword.ToLower())))
            .ToListAsync(cancellationToken);
        
        return list.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).ToList();
    }

    public int GetTotalCustomers(string keyword = null)
    {
        return _context.Customers
            .Where(p => (string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword.ToLower()) || p.Phone.ToLower().Contains(keyword.ToLower())))
            .Count();
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public void UpdateCustomerRange(List<Customer> customers)
    {
        _context.Customers.UpdateRange(customers);
    }
}
