using AutoMapper;
using Entities;
using Infrastructur.DTO;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductServices : IProductService
    {
        public ProductDbContext Context { get; set;  }
        public IMapper Mapper { get; set; }
        public ProductServices(ProductDbContext productDbContext, IMapper mapper) 
        {
            Mapper = mapper;
            Context = productDbContext;
        }
        public decimal GetPriceAllProducts()
        {
            var list  = Context.Products.Where(x => x.Price != null).Select(x => x.Price);
            decimal? sum = 0;
            foreach (var item in list)
            {
                if (item!=null)
                {
                    sum+=item;
                }
            }
            return sum.GetValueOrDefault();
            
        }

        public ProductDTO GetProduct(int id)
        {
            var product = Context.Products.Where(x => x.Id==id).FirstOrDefault();
            var result = Mapper.Map<ProductDTO>(product);
            return result;
        }

        public List<ProductDTO> GetProducts()
        {
            var list = Context.Products.ToList();
            var result = Mapper.Map<List<ProductDTO>>(list);
            return result;
        }

        public void AddProduct(ProductDTO productDTO)
        {
            var product = Mapper.Map<Product>(productDTO);
            Context.Products.Add(product);
            Save();
        }

        public void UpdateProduct(ProductDTO productDTO, int id)
        {
            var product = Mapper.Map<Product>(productDTO);
            product.Id= id;
            Context.Products.Update(product);
            Save();
        }

        public void DeleteProduct(int id)
        {
            var product = Context.Products.Where(x => x.Id==id).FirstOrDefault();
            Context.Products.Remove(product);
            Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
