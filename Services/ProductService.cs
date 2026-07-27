using first_dotnet_app.DTOs.Requests;
using first_dotnet_app.DTOs.Respose;
using first_dotnet_app.Interfaces;
using first_dotnet_app.Models;

namespace first_dotnet_app.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        private static ProductResponse MapToResponse(Product prduct)
        {
            return new ProductResponse()
            {
                Id = prduct.Id,
                Name = prduct.Name,
                Description = prduct.Description,
                Price = prduct.Price,
            };
        }

        public IEnumerable<ProductResponse> GetAll()
        {
            //return _repository.GetAll().Select(p => MapToResponse(p));
            return _repository.GetAll().Select(MapToResponse);
        }

        public ProductResponse? GetById(int id)
        {
            var product = _repository.GetById(id);

            if (product == null) return null;
            return MapToResponse(product);
        }
        public ProductResponse Create(CreateProductRequest request)
        {
            var _products = _repository.GetAll();

            var nextId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;

            var product = new Product
            {
                Id = nextId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            };

            _repository.Create(product);

            return MapToResponse(product);
        }
        public bool Update(int id, UpdateProductRequest request)
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

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

    }
}
