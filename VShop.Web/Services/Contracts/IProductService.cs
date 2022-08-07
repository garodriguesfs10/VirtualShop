using VShop.Web.Models;

namespace VShop.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts(string token);
        Task<ProductViewModel> FindProductById(int productId , string token);
        Task<ProductViewModel> CreateProduct(ProductViewModel product, string token);
        Task<ProductViewModel> UpdateProduct(ProductViewModel product, string token);
        Task<bool> DeleteProduct(int id, string token);



    }
}
