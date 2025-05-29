using Microsoft.AspNetCore.Mvc;
using storedprocedureincrud.Models;
using storedprocedureincrud.Service;

namespace storedprocedureincrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            return product != null ? Ok(product) : NotFound();
        }


        [HttpPost]
        public IActionResult Create([FromBody] ProductModel product)
        {
            _service.Create(product);
            return Ok(new { message = "Product created successfully" });
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductModel product)
        {
            product.Id = id;
            _service.Update(product);
            return Ok(new { message = "Product updated successfully" });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
