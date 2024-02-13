using OneOf;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Unit.Ins;
using StorageSystem.Application.Models.Unit.Outs;
using StorageSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace StorageSystem.Application.Contracts.Services
{
    public interface IUnitService
    {
        Task<OneOf<IEnumerable<GetUnitForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllUnits(Paging filter);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateUnit(CreateUnitInsDto unitDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateUnit(Guid unitId, UpdateUnitInsDto unitDto);

        Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteUnit(Guid id);

        Task<OneOf<GetUnitForView, LocalizationErrorMessageOutDto, ValidationResult>> FindUnitById(Guid id);
    }
}
