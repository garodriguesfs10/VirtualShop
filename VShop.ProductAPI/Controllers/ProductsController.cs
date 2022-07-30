﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Services.Interfaces;

namespace VShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var produtosDTO = await _productService.GetProducts();

            if (produtosDTO == null) return NotFound("Produtos não encontradas");

            return Ok(produtosDTO);

        }

        // Usar ActionResult Pois Podem mais de um tipo de result       

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductById(int id)
        {
            var produtoDTO = await _productService.GetProductById(id);

            if (produtoDTO == null) return NotFound("Produto não encontrada");

            return Ok(produtoDTO);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO ProductDTO)
        {
            if (ProductDTO == null) return BadRequest("Dados inválidos");

            await _productService.AddProduct(ProductDTO);

            return new CreatedAtRouteResult("GetProductById", new { id = ProductDTO.Id }, ProductDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO ProductDTO)
        {
            if (id != ProductDTO.Id) return BadRequest();

            if (ProductDTO == null) return BadRequest();

            await _productService.UpdateProduct(ProductDTO);

            return Ok(ProductDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var produtoDTO = await _productService.GetProductById(id);

            if (produtoDTO == null) return NotFound("Produto não encontrada");

            await _productService.DeleteProduct(id);

            return Ok(produtoDTO);
        }
    }
}