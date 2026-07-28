using first_dotnet_app.DTOs.Requests;
using first_dotnet_app.DTOs.Respose;

namespace first_dotnet_app.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductResponse> GetAll();

        ProductResponse? GetById(Guid id);

        ProductResponse Create(CreateProductRequest request);

        bool Update(Guid id , UpdateProductRequest request);

        bool Delete(Guid id);
    }
}
