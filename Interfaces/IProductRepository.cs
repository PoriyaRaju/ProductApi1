using first_dotnet_app.Models;

namespace first_dotnet_app.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetAll();

        Product? GetById(Guid id);

        Product Create(Product product);

        bool Update(Product product);

        bool Delete(Guid id);
    }
}
