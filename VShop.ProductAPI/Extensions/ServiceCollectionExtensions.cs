using VShop.ProductAPI.Repositories.Implementation;
using VShop.ProductAPI.Repositories.Interfaces;
using VShop.ProductAPI.Services.Implementation;
using VShop.ProductAPI.Services.Interfaces;

namespace VShop.ProductAPI.Extensions
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddLifeCycle(this IServiceCollection services) 
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
