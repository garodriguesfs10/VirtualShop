using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();        
        Task<Product> GetById(int id);
        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<bool> Delete(int id);
    }
}
