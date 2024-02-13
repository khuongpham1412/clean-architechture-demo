using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Unit.Ins;

namespace StorageSystem.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUnit([FromBody] CreateUnitInsDto unitDto)
        {
            var result = await _unitService.CreateUnit(unitDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnits([FromQuery] Paging paging)
        {
            var result = await _unitService.GetAllUnits(paging);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindUnitById(Guid id)
        {
            var result = await _unitService.FindUnitById(id);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                res => BadRequest(res)
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUnit(Guid id, [FromBody] UpdateUnitInsDto unit)
        {
            var result = await _unitService.UpdateUnit(id, unit);
            return result.Match<IActionResult>(
                _ => NoContent(),
                BadRequest,
                BadRequest
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(Guid id)
        {
            var result = await _unitService.DeleteUnit(id);
            return result.Match<IActionResult>(
                _ => NoContent(),
                r1 => Ok(result.AsT1),
                r2 => Ok(result.AsT2)
            );
        }
    }
}
