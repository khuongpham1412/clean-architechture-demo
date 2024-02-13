using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Application.Models.Bases;
using OneOf;
using OneOf.Types;
using StorageSystem.Domain.Entities;
using NPOI.SS.Formula.Functions;
using StorageSystem.Application.Models.Category.Ins;
using StorageSystem.Application.Contracts.Services;

namespace StorageSystem.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryInsDto categoryDto)
        {
            var result = await _categoryService.CreateCategory(categoryDto);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] Paging paging)
        {
            var result = await _categoryService.GetAllCategories(paging);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                BadRequest
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindCategoryById(Guid id)
        {
            var result = await _categoryService.FindCategoryById(id);
            return result.Match<IActionResult>(
                _ => Ok(result.AsT0),
                BadRequest,
                res => BadRequest(res)
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryInsDto category)
        {
            var result = await _categoryService.UpdateCategory(id, category);
            return result.Match<IActionResult>(
                _ => NoContent(),
                BadRequest,
                BadRequest
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return result.Match<IActionResult>(
                _ => NoContent(),
                r1 => Ok(result.AsT1),
                r2 => Ok(result.AsT2)
            );
        }
    }
}
