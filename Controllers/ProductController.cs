
using first_dotnet_app.DTOs.Requests;
using first_dotnet_app.DTOs.Respose;
using first_dotnet_app.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace first_dotnet_app.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetById(int id)
        {
            var product = _service.GetById(id);

            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductResponse> Create(CreateProductRequest request)
        {
            var product = _service.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = 10 }, product);
        }

        [HttpPatch("{id}")]
        public ActionResult<bool> Update(int id, UpdateProductRequest request)
        {
            Console.WriteLine($"{id} \t ${request.ToString()}");
            bool flag =  _service.Update(id, request);
            Console.WriteLine(flag);
            return flag;
        }


        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _service.Delete(id);
        }

    }

}


