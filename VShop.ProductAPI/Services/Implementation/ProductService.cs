using AutoMapper;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories.Interfaces;
using VShop.ProductAPI.Services.Interfaces;

namespace VShop.ProductAPI.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity = await _ProductRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _ProductRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }
       
        public async Task AddProduct(ProductDTO ProductDTO)
        {
            var produtoEntity = _mapper.Map<Product>(ProductDTO);
            await _ProductRepository.Create(produtoEntity);
            ProductDTO.Id = produtoEntity.Id;
        }

        public async Task DeleteProduct(int id)
        {
            var productEntity = _ProductRepository.GetById(id).Result;
            await _ProductRepository.Delete(productEntity.Id);
        }

        public async Task UpdateProduct(ProductDTO ProductDTO)
        {
            var productEntity = _mapper.Map<Product>(ProductDTO);
            await _ProductRepository.Update(productEntity);
        }
    }
}
