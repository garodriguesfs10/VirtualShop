using VShop.ProductAPI.DTOs;

namespace VShop.ProductAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
        Task<CategoryDTO> GetCategoryById(int id);
        Task AddCategory(CategoryDTO category);
        Task DeleteCategory(int id);
        Task UpdateCategory(CategoryDTO category);
    }
}
