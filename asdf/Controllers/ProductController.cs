using Entities;
using Infrastructur.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace asdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService ProductService { get; set; }
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }
        [HttpGet(nameof(GetProducts))]

        public List<Product> GetProducts()
        {
            return ProductService.GetProducts();
        }

        [HttpGet(nameof(GetProduct))]
        public Product GetProduct(int id)
        {
            return ProductService.GetProduct(id);
        }

        [HttpGet(nameof(GetProductPrice))]
        public decimal GetProductPrice()
        {
            return ProductService.GetPriceAllProducts();
        }

        [HttpPost]
        public void AddProduct([FromBody] Product product)
        {
            ProductService.AddProduct(product);
        }

        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
            ProductService.UpdateProduct(product);
        }

        [HttpDelete(nameof(DeleteProduct))]
        public void DeleteProduct(int id)
        {
            ProductService.DeleteProduct(id);
        }

        [HttpGet]
        public string str()
        {
            return "Test";
        }
    }
}
