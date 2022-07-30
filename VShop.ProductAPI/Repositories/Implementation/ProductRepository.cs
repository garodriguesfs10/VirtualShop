using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Context;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories.Interfaces;

namespace VShop.ProductAPI.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }       

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(c => c.Category).Where(p => p.Id == id).FirstOrDefaultAsync();
        }       


        public async Task<Product> Create(Product Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return Product;
        }

        public async Task<Product> Update(Product Product)
        {
            _context.Entry(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Product;
        }

        public async Task<bool> Delete(int id)
        {
            var produto = await GetById(id);
            if (produto != null)
            {
                _context.Products.Remove(produto);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }       

       
    }
}
