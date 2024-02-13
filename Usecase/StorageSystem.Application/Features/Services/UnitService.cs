using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using OneOf;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Unit.Ins;
using StorageSystem.Application.Models.Unit.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Features.Services
{
    public class UnitService : IUnitService
    {
        private readonly ILogger<UnitService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UnitService(ILogger<UnitService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateUnit(CreateUnitInsDto unitDto)
        {
            _logger.LogInformation($"Start create unit");
            Unit unit = _mapper.Map<Unit>(unitDto);
            try
            {
                await _unitOfWork.UnitDataAccess.CreateUnitAsync(unit);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create unit {ex.Message}!");
                return false;
            }
            return true;
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteUnit(Guid id)
        {
            var unit = await _unitOfWork.UnitDataAccess.FindUnitById(id);
            if (unit != null)
            {
                try
                {
                    _logger.LogInformation($"Start delete unit");
                    _unitOfWork.UnitDataAccess.DeleteUnit(unit);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when delete unit {ex.Message}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists unit!", "400000")
                       }
                   );
        }

        public async Task<OneOf<GetUnitForView, LocalizationErrorMessageOutDto, ValidationResult>> FindUnitById(Guid id)
        {
            var result = await _unitOfWork.UnitDataAccess.FindUnitById(id);
            if (result != null)
            {
                return _mapper.Map<GetUnitForView>(result);
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists unit!", "400000")
                       }
                   );
        }

        public async Task<OneOf<IEnumerable<GetUnitForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllUnits(Paging filter)
        {
            IEnumerable<Unit> units = await _unitOfWork.UnitDataAccess.GetAllUnits(true);
            IEnumerable<GetUnitForView> data = _mapper.Map<IEnumerable<GetUnitForView>>(units);
            return data.ToList();
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateUnit(Guid unitId, UpdateUnitInsDto unitDto)
        {
            Unit unit = await _unitOfWork.UnitDataAccess.FindUnitById(unitId);
            if (unit != null)
            {
                _logger.LogInformation($"Start update unit");
                //unit.Name = unitDto.Name;

                try
                {
                    _unitOfWork.UnitDataAccess.UpdateUnit(unit);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when update unit {ex.Message}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists unit!", "400000")
                       }
                   );
        }
    }
}
