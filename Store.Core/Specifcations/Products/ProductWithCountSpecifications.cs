using Store.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifcations.Products
{
    public class ProductWithCountSpecifications : BaseSpecifcations<Product, int>
    {
        public ProductWithCountSpecifications(ProductSpecPrams producSpecPrams)
            : base(P =>
                  (string.IsNullOrEmpty(producSpecPrams.Search) || P.Name.ToLower().Contains(producSpecPrams.Search))
                  &&
                  (!producSpecPrams.BrandId.HasValue || producSpecPrams.BrandId == P.Brand.Id)
                  &&
                  (!producSpecPrams.TypeId.HasValue || producSpecPrams.TypeId == P.Type.Id))

        {

        }

    }
}
