using Store.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifcations.Products
{
    public class ProductSpecifications : BaseSpecifcations<Product, int>
    {
        public ProductSpecifications(ProductSpecPrams producSpecPrams) 
            : base(P =>
                  (string.IsNullOrEmpty(producSpecPrams.Search) || P.Name.ToLower().Contains(producSpecPrams.Search))
                  &&
                  (!producSpecPrams.BrandId.HasValue || producSpecPrams.BrandId == P.Brand.Id)
                  &&
                  (!producSpecPrams.TypeId.HasValue || producSpecPrams.TypeId == P.Type.Id))



        {
            if (!string.IsNullOrEmpty(producSpecPrams.Sort))
            {
                var res = producSpecPrams.Sort.ToLower();
                switch (res)
                {
                    case "name":
                        OrderBy = P => P.Name;
                        break;
                    case "priceasc":
                        OrderBy = P => P.Price;
                        break;
                    case "pricedesc":
                        OrderByDescending = P => P.Price;
                        break;
                    default:
                        break;
                }
            }


            
            AddIncludes();


            ApplyPagination(producSpecPrams.PageSize * (producSpecPrams.PageIndex - 1), producSpecPrams.PageSize);
        }


        public ProductSpecifications(int id)
        {
            Cretria = P => P.Id == id;
            AddIncludes();
        }

        private void AddIncludes()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Type);
        }
    }
}
