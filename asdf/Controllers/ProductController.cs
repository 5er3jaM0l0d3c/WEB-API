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

        public List<ProductDTO> GetProducts()
        {
            return ProductService.GetProducts();
        }

        [HttpGet(nameof(GetProduct))]
        public ProductDTO GetProduct(int id)
        {
            return ProductService.GetProduct(id);
        }

        [HttpGet(nameof(GetProductPrice))]
        public decimal GetProductPrice()
        {
            return ProductService.GetPriceAllProducts();
        }

        [HttpPost]
        public void AddProduct(ProductDTO product)
        {
            ProductService.AddProduct(product);
        }

        [HttpPut]
        public void UpdateProduct(ProductDTO product, int id)
        {
            ProductService.UpdateProduct(product, id);
        }

        [HttpDelete]
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
