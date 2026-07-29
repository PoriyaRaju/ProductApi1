using first_dotnet_app.Data;
using first_dotnet_app.Interfaces;
using first_dotnet_app.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace first_dotnet_app.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        async public Task<IEnumerable<Product?>> GetAll()
        {
            var products = await _context.Products
                        .AsNoTracking()
                        .ToListAsync();

            return products;
        }

        public Product? GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product Create(Product product)
        {
            _products.Add(product);
            return product;
        }

        public bool Update(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);

            if (existing == null)
            {
                Console.WriteLine("retun false");
                return false;
            }

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;

            Console.WriteLine("retun true");
            return true;
        }

        public bool Delete(Guid id)
        {
            var product = _products.FirstOrDefault(_ => _.Id == id);

            if (product == null)
            {
                return false;
            }

            _products.Remove(product);

            return true;
        }
    }
}
