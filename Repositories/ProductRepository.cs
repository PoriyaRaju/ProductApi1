using first_dotnet_app.Interfaces;
using first_dotnet_app.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace first_dotnet_app.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new()
        {
            new Product
            {
                Name="Laptop",
                Description="Dell i3 11th Gen",
                Price = 20000
            }
        };

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
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
