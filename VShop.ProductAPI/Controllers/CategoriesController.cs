using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Roles;
using VShop.ProductAPI.Services.Interfaces;

namespace VShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // Usar ActionResult Pois Podem mais de um tipo de result
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriasDTO = await _categoryService.GetCategories();

            if (categoriasDTO == null) return NotFound("Categorias não encontradas");

            return Ok(categoriasDTO);

        }

        // Usar ActionResult Pois Podem mais de um tipo de result
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriasDTO = await _categoryService.GetCategoriesProducts();

            if (categoriasDTO == null) return NotFound("Categorias não encontradas");

            return Ok(categoriasDTO);

        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryById(int id)
        {
            var categoriaDTO = await _categoryService.GetCategoryById(id);

            if (categoriaDTO == null) return NotFound("Categoria não encontrada");

            return Ok(categoriaDTO);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest("Dados inválidos");

            await _categoryService.AddCategory(categoryDTO);

            return new CreatedAtRouteResult("GetCategoryById", new { id = categoryDTO.CategoryId }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if ( id !=  categoryDTO.CategoryId) return BadRequest();

            if (categoryDTO == null) return BadRequest();

            await _categoryService.UpdateCategory(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoriaDTO = await _categoryService.GetCategoryById(id);

            if (categoriaDTO == null) return NotFound("Categoria não encontrada");

            await _categoryService.DeleteCategory(id);

            return Ok(categoriaDTO);
        }
    }
}
