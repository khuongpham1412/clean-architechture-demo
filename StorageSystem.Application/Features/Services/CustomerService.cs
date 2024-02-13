using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using OneOf;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Customer.Ins;
using StorageSystem.Application.Models.Customer.Outs;
using StorageSystem.Application.Models.Product.Base;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Application.Models.Product.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Features.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(ILogger<CustomerService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateCustomer(CreateCustomerInsDto customerDto)
        {
            _logger.LogInformation($"Start create customer");
            Customer customer = _mapper.Map<Customer>(customerDto);
            try
            {
                await _unitOfWork.CustomerDataAccess.CreateCustomerAsync(customer);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create customer {ex.Message}!");
                return false;
            }
            return true;
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteCustomer(Guid id)
        {
            var customer = await _unitOfWork.CustomerDataAccess.FindCustomerById(id);
            if (customer != null)
            {
                try
                {
                    _logger.LogInformation($"Start delete customer");
                    _unitOfWork.CustomerDataAccess.DeleteCustomer(customer);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when delete customer {ex.Message}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists customer!", "400000")
                       }
                   );
        }

        public async Task<OneOf<GetCustomerForView, LocalizationErrorMessageOutDto, ValidationResult>> FindCustomerById(Guid id)
        {
            var result = await _unitOfWork.CustomerDataAccess.FindCustomerById(id);
            if (result != null)
            {
                return _mapper.Map<GetCustomerForView>(result);
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists customer!", "400000")
                       }
                   );
        }

        public async Task<OneOf<GetCustomerForView, LocalizationErrorMessageOutDto, ValidationResult>> GetAllCustomers(FilterCustomer filter)
        {
            _logger.LogInformation("Start get all customers!");
            IEnumerable<Customer> customers = await _unitOfWork.CustomerDataAccess.GetAllCustomers(filter, true);
            GetCustomerForView data = new GetCustomerForView();
            data.Customers = _mapper.Map<List<CustomerList>>(customers);
            data.Total = _unitOfWork.CustomerDataAccess.GetTotalCustomers(filter.Keyword);
            return data;
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateCustomer(Guid customerId, UpdateCustomerInsDto customerDto)
        {
            Customer customer = await _unitOfWork.CustomerDataAccess.FindCustomerById(customerId);
            if (customer != null)
            {
                _logger.LogInformation($"Start update customer");
                //customer = _mapper.Map<Customer>(customerDto);
                customer.Phone = customerDto.Phone;
                customer.Name = customerDto.Name;
                customer.Address = customerDto.Address;

                try
                {
                    _unitOfWork.CustomerDataAccess.UpdateCustomer(customer);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when update customer {ex.Message}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists customer!", "400000")
                       }
                   );
        }
    }
}
