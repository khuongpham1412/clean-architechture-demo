using OneOf;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using StorageSystem.Application.Models.Customer.Ins;
using StorageSystem.Application.Models.Customer.Outs;

namespace StorageSystem.Application.Contracts.Services
{
    public interface ICustomerService
    {
        Task<OneOf<GetCustomerForView, LocalizationErrorMessageOutDto, ValidationResult>> GetAllCustomers(FilterCustomer filter);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateCustomer(CreateCustomerInsDto customerDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateCustomer(Guid customerId, UpdateCustomerInsDto customerDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteCustomer(Guid id);

        Task<OneOf<GetCustomerForView, LocalizationErrorMessageOutDto, ValidationResult>> FindCustomerById(Guid id);
    }
}
