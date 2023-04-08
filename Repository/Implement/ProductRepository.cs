using Microsoft.EntityFrameworkCore;
using Moqayda.API.Data;
using Moqayda.API.Entities;
using Moqayda.API.Repository.Abstruct;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moqayda.API.Repository.Implement
{
    public class ProductRepository : IProductRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public ProductRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            DbContext.Product.Add(product);
            await DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var productToRemove = await DbContext.Product.FindAsync(productId);
            DbContext.Remove(productToRemove);
            
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Product GetProduct(int productId)
        {
            return this.DbContext.Product.Find(productId);
        }

        public Task<Product> GetProductAsync(int productId)
        {
            return this.DbContext.Product.FindAsync(productId).AsTask();
        }

        public Task<Product> GetProductByNameAsync(string name)
        {
            return this.DbContext.Product.FirstOrDefaultAsync(f => f.ProductName.ToLower() == name.ToLower());
        }

        public List<Product> GetProducts(int noOfProducts = 100)
        {
            var products = this.DbContext.Product.OrderByDescending(o => o.CreatedDate).Take(noOfProducts).ToList();
            return products;
        }

        public Task<List<Product>> GetProductsAsync(int noOfProducts = 100)
        {
            var products = DbContext.Product.OrderByDescending(o => o.CreatedDate).Take(noOfProducts).ToListAsync();
            return products;
        }

        public Task<Product> GetProductByNameAsync(string name, int id)
        {
            return DbContext.Product.AsNoTracking().FirstOrDefaultAsync(f => f.ProductName.ToLower() == name.ToLower() && f.Id != id);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            DbContext.Product.Update(product);
            await DbContext.SaveChangesAsync();
            return product;
        }
    }
}
