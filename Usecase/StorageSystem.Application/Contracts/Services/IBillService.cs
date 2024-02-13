using OneOf;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using StorageSystem.Application.Models.Bill.Ins;
using StorageSystem.Application.Models.Bill.Outs;

namespace StorageSystem.Application.Contracts.Services
{
    public interface IBillService
    {
        Task<OneOf<IEnumerable<GetBillForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllBills(Paging filter);

        Task<OneOf<IEnumerable<GetBillForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllBillDetailsFromBillId();

        Task<OneOf<IEnumerable<GetBillForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllBillDetailsFromPhone(string phone);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateBill(CreateBillInsDto billDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateBill(Guid billId, UpdateBillInsDto billDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteBill(Guid id);

        Task<OneOf<GetBillForView, LocalizationErrorMessageOutDto, ValidationResult>> FindBillById(Guid id);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> ReplacementBill(ReplacementBillInsDto model);
    }
}
