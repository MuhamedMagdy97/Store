using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Core.Dtos.Products;
using Store.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Mapping.Products
{
    public class ProductProfile : Profile
    {
        private readonly IConfiguration _configuration;

        //public ProductProfile(IConfiguration configuration)
        //{
        //    _configuration = configuration;

        //    CreateMap<Product, ProductDto>()
        //        .ForMember(d => d.BrandName, options => options.MapFrom(s => s.Brand.Name))
        //        .ForMember(d => d.TypeName, options => options.MapFrom(s => s.Type.Name))
        //        .ForMember(d => d.PictureUrl, options => options.MapFrom(s => $"{_configuration["BaseUrl"]}{s.PictureUrl}"))
        //        ;

        //    CreateMap<ProductBrand, TypeBrandDto>();
        //    CreateMap<ProductType, TypeBrandDto>();
        //}

        public ProductProfile(IConfiguration configuration)
        {
            _configuration = configuration;

            CreateMap<Product, ProductDto>()
                .ForMember(d => d.BrandName, options => options.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.TypeName, options => options.MapFrom(s => s.Type.Name))
                .ForMember(d => d.PictureUrl, options => options.MapFrom(new PicUrlResolver(configuration)));
                ;

            CreateMap<ProductBrand, TypeBrandDto>();
            CreateMap<ProductType, TypeBrandDto>();
        }
    }
}
