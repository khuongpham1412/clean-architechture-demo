using OneOf;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Order.Ins;
using StorageSystem.Application.Models.Order.Outs;
using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using StorageSystem.Domain.Enums;

namespace StorageSystem.Application.Contracts.Services
{
    public interface IOrderService
    {
        Task<OneOf<List<GetOrderForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllOrders(Paging filter);

        Task<OneOf<List<GetOrderForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllOrderDetailsFromOrderId();

        Task<OneOf<List<GetOrderForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllOrderDetailsFromPhone(string phone);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> PrintInvoice(CreateOrderInsDto orderDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CancelledOrder(CancelledOrderInsDto orderDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateOrder(Guid customerId, UpdateOrderInsDto orderDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteOrder(Guid id);

        Task<OneOf<List<GetOrderForView>, LocalizationErrorMessageOutDto, ValidationResult>> FindAllOrdersById(Guid id);
    }
}
