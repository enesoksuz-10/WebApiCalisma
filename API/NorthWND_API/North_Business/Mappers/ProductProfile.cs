using AutoMapper;
using North_Model.Concreate.DTOs;
using North_Model.Concreate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North_Business.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ForCreationProductDTO, Product>();
            CreateMap<Product, ProductGetDTO>()
                .ForMember(dto => dto.CategoryName, entity => entity.MapFrom(x => x.Category.CategoryName));
            //.ForMember(dto => dto.ProductName, entity => entity.MapFrom(x => x.ProductName))
            //.ForMember(dto => dto.UnitPrice, entity => entity.MapFrom(x => x.UnitPrice))
            //.ForMember(dto => dto.UnitsInStock, entity => entity.MapFrom(x => x.UnitsInStock))

        }
    }
}
