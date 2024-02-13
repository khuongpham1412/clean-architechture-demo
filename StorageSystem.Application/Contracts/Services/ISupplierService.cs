using OneOf;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Supplier.Ins;
using StorageSystem.Application.Models.Supplier.Outs;
using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace StorageSystem.Application.Contracts.Services
{
    public interface ISupplierService
    {
        Task<OneOf<IEnumerable<GetSupplierForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllSuppliers(Paging filter);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateSupplier(CreateSupplierInsDto supplierDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateSupplier(Guid supplierId, UpdateSupplierInsDto supplierDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteSupplier(Guid id);

        Task<OneOf<GetSupplierForView, LocalizationErrorMessageOutDto, ValidationResult>> FindSupplierById(Guid id);
    }
}
