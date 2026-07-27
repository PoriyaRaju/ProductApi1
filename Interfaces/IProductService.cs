using first_dotnet_app.DTOs.Requests;
using first_dotnet_app.DTOs.Respose;

namespace first_dotnet_app.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductResponse> GetAll();

        ProductResponse? GetById(int id);

        ProductResponse Create(CreateProductRequest request);

        bool Update(int id , UpdateProductRequest request);

        bool Delete(int id);
    }
}
