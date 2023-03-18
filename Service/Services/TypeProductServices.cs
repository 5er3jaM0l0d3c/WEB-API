using AutoMapper;
using Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TypeProductServices : ITypeProduct
    {
        public ProductDbContext Context { get; set; }

        public TypeProductServices(ProductDbContext productDbContext)
        { 
            
            Context = productDbContext;
        }
        public void AddTypeProduct(TypeProduct typeProduct)
        {
            Context.TypeProducts.Add(typeProduct);
            Save();
        }
        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
