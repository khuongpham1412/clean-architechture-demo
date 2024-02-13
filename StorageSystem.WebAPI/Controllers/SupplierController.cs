using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Supplier.Ins;

namespace StorageSystem.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] CreateSupplierInsDto supplierDto)
        {
            var result = await _supplierService.CreateSupplier(supplierDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers([FromQuery] Paging paging)
        {
            var result = await _supplierService.GetAllSuppliers(paging);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindSupplierById(Guid id)
        {
            var result = await _supplierService.FindSupplierById(id);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                res => BadRequest(res)
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSupplier(Guid id, [FromBody] UpdateSupplierInsDto supplier)
        {
            var result = await _supplierService.UpdateSupplier(id, supplier);
            return result.Match<IActionResult>(
                _ => NoContent(),
                BadRequest,
                BadRequest
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            var result = await _supplierService.DeleteSupplier(id);
            return result.Match<IActionResult>(
                _ => NoContent(),
                r1 => Ok(result.AsT1),
                r2 => Ok(result.AsT2)
            );
        }
    }
}
