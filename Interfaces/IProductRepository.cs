using first_dotnet_app.Models;

namespace first_dotnet_app.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product? GetById(int id);

        Product Create(Product product);

        bool Update(Product product);

        bool Delete(int id);
    }
}
