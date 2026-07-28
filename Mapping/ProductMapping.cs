using first_dotnet_app.DTOs.Respose;
using first_dotnet_app.Models;

namespace first_dotnet_app.Mappings
{
    public static class ProductMapping
    {
        public static ProductResponse ToResponse(this Product product)
        {
            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
}