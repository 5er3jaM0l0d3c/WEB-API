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
        List<Product> GetProducts();
        Product GetProduct(int id);
        decimal GetPriceAllProducts();

        void AddProduct(Product product);

        void UpdateProduct(Product product);
        
        void DeleteProduct(int id);
    }
}
