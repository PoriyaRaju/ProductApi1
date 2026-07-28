using first_dotnet_app.DTOs.Requests;
using first_dotnet_app.DTOs.Respose;
using first_dotnet_app.Interfaces;
using first_dotnet_app.Models;
using first_dotnet_app.Mappings;

namespace first_dotnet_app.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<ProductResponse> GetAll()
        {
            //return _repository.GetAll().Select(p => MapToResponse(p));
            return _repository.GetAll().Select(p => p.ToResponse());
        }

        public ProductResponse? GetById(Guid id)
        {
            var product = _repository.GetById(id);

            if (product == null) return null;
            return product.ToResponse();
        }
        public ProductResponse Create(CreateProductRequest request)
        {
            var _products = _repository.GetAll();

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            };

            _repository.Create(product);

            return product.ToResponse();
        }
        public bool Update(Guid id, UpdateProductRequest request)
        {
            var existing = _repository.GetById(id);

            if (existing == null) return false;

            var product = new Product()
            {
                Id = existing.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            return _repository.Update(product);
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

    }
}
