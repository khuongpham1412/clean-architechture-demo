using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Features.Services;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Bill.Ins;
using StorageSystem.Application.Models.Category.Ins;

namespace StorageSystem.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService) 
        {
            _billService = billService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillInsDto billDto)
        {
            var result = await _billService.CreateBill(billDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBill(Guid id, [FromBody] UpdateBillInsDto billDto)
        {
            var result = await _billService.UpdateBill(id, billDto);
            return result.Match<IActionResult>(
                _ => NoContent(),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBills([FromQuery] Paging paging)
        {
            var result = await _billService.GetAllBills(paging);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindBillById(Guid id)
        {
            var result = await _billService.FindBillById(id);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                res => BadRequest(res)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(Guid id)
        {
            var result = await _billService.DeleteBill(id);
            return result.Match<IActionResult>(
                _ => NoContent(),
                r1 => Ok(result.AsT1),
                r2 => Ok(result.AsT2)
            );
        }
    }
}
