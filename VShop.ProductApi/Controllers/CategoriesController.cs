using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            IEnumerable<CategoryDTO> categoriesDto = await _categoryService.GetCategories();

            if (categoriesDto != null)
            {
                return Ok(categoriesDto);
            }

            return NotFound("Categories not nound");
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            IEnumerable<CategoryDTO> categoriesDto = await _categoryService.GetCategoriesProducts();

            if (categoriesDto != null)
            {
                return Ok(categoriesDto);
            }

            return NotFound("Categories not found");
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            CategoryDTO categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto is null)
                return NotFound("Category not found");

            return Ok(categoryDto);
            
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post(CategoryDTO categoryDto)
        {
            if (categoryDto is null)
            {
                return BadRequest("Invalida data");
            }

            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Put(int id, CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId)
                return BadRequest("Invalid data");
            

            if (categoryDto is null)
                return BadRequest("Invalid data");

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            CategoryDTO categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto is null)
            {
                return NotFound("Category not found");
            }

            await _categoryService.RemoveCategory(id);

            return Ok(categoryDto);
        }
    }
}
