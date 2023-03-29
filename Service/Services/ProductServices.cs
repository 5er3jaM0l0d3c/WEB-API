using AutoMapper;
using Entities;
using Infrastructur.DTO;
using Microsoft.EntityFrameworkCore;
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
        public ProductDbContext Context { get; set; }
        public ProductServices(ProductDbContext productDbContext) 
        {
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

        public Product GetProduct(int id)
        {
            var product = Context.Products.Where(x => x.Id==id).FirstOrDefault();
            return product;
        }

        public List<Product> GetProducts()
        {
            var list = Context.Products.Include(t=>t.TypeProduct).ToList();
            return list;
        }

        public void AddProduct(Product product)
        {
            Context.Products.Add(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
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
