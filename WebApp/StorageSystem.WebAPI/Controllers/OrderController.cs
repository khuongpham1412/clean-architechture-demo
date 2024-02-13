using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Features.Services;
using StorageSystem.Application.Models.Bill.Ins;
using StorageSystem.Application.Models.Order.Ins;

namespace StorageSystem.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("print-invoice")]
        public async Task<IActionResult> PrintInvoice([FromBody] CreateOrderInsDto orderDto)
        {
            var result = await _orderService.PrintInvoice(orderDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpPost("cancelled-order")]
        public async Task<IActionResult> CancelledOrder([FromBody] CancelledOrderInsDto orderDto)
        {
            var result = await _orderService.CancelledOrder(orderDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpPatch("{customerId}")]
        public async Task<IActionResult> UpdateOrder(Guid customerId, [FromBody] UpdateOrderInsDto orderDto)
        {
            var result = await _orderService.UpdateOrder(customerId, orderDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }
    }
}
