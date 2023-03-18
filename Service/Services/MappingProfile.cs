using AutoMapper;
using Entities;
using Infrastructur.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDTO>(); 
            CreateMap<Product, ProductDTO>().ReverseMap();
          
        }
        
    }
}
