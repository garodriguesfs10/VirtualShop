using VShop.ProductAPI.DTOs;

namespace VShop.ProductAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();     
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task DeleteProduct(int id);
        Task UpdateProduct(ProductDTO productDTO);
    }
}
