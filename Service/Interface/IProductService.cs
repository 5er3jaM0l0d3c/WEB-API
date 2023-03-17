using Entities;
using Infrastructur.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        ProductDTO GetProduct(int id);
        decimal GetPriceAllProducts();

        void AddProduct(ProductDTO product);

        void UpdateProduct(ProductDTO product, int id);
        
        void DeleteProduct(int id);
    }
}
