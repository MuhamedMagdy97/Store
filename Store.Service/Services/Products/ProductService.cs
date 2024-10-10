using AutoMapper;
using Store.Core;
using Store.Core.Dtos.Products;
using Store.Core.Entites;
using Store.Core.Helper;
using Store.Core.Services.interfaces;
using Store.Core.Specifcations;
using Store.Core.Specifcations.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IuniteOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IuniteOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginationRespons<ProductDto>> GetAllProductsAsync(ProductSpecPrams producSpecPrams)
        {
            var spec = new ProductSpecifications(producSpecPrams);

            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(spec);
            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);


            var countSpec = new ProductWithCountSpecifications(producSpecPrams);


            var count = await _unitOfWork.Repository<Product, int>().GetCountAsync(countSpec);


            return new PaginationRespons<ProductDto>(producSpecPrams.PageSize, producSpecPrams.PageIndex, count, mappedProducts);
        }

        public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync() => _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());
        
        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync() => _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());

        public async Task<ProductDto> GetProductById(int id)
        {
            var spec = new ProductSpecifications(id);
           var product = await _unitOfWork.Repository<Product , int>().GetWithSpecAsync(spec);
            var mappedProduct = _mapper.Map<ProductDto>(product);
            return mappedProduct;
        }

    }
}
