using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Services;

namespace asdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProductController : ControllerBase
    {
        public ITypeProduct TypeProduct { get; set; }

        public TypeProductController(ITypeProduct typeProduct)
        {
            TypeProduct = typeProduct;
        }

        [HttpPost]
        public void AddTypeProduct(TypeProduct typeProduct)
        {
            TypeProduct.AddTypeProduct(typeProduct);
        }
    }
}
