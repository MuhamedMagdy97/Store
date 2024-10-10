using Store.Core.Dtos.Products;
using Store.Core.Entites;
using Store.Core.Helper;
using Store.Core.Specifcations.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.interfaces
{
    public interface IProductService
    {
        Task<PaginationRespons<ProductDto>> GetAllProductsAsync(ProductSpecPrams producSpecPrams);
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductById(int id);
    }
}
