using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Dal.Concrete.EntityFramework
{
    public class BrandDal:RepositoryBase<Brand>,IBrandDal
    {
        UdemyETicaretDBContext ctx = new UdemyETicaretDBContext();

        public List<ProductBrand> BrandsOfProduct(string brandsOfProduct, decimal? minValue, decimal?maxValue)
        {
            List<ProductBrand> productBrands = new List<ProductBrand>();
            ProductBrand productBrand;
            if (!minValue.HasValue && !maxValue.HasValue)
            {
                
                var col = ctx.Products.Join(
                    ctx.Brands,
                    p => p.ProductBrandID,
                    b => b.id,
                    (pro, brand) => new
                    {
                        BrandId= brand.id,
                        BrandName= brand.name,
                        ProductName=pro.Name,
                        stok=brand.name
                    }
                ).Where(x => x.ProductName.Contains(brandsOfProduct)).GroupBy(x => x.BrandName).Select
                    (
                    x => new 
                        { stok = x.Count(), 
                            x.FirstOrDefault().BrandId, 
                            x.FirstOrDefault().ProductName, 
                            x.FirstOrDefault().BrandName
                        }
                    ).ToList();
            
            foreach (var a in col)
            {
              
                productBrand= new ProductBrand
                {
                    productName = a.ProductName,
                    brandId = a.BrandId,
                    brandName = a.BrandName,
                    stok=a.stok,
                 

                };
                productBrands.Add(productBrand);
            }
            return productBrands.ToList();
            }
            else
            {
                var col = ctx.Products.Join(
                    ctx.Brands,
                    p => p.ProductBrandID,
                    b => b.id,
                    (pro, brand) => new
                    {
                        BrandId = brand.id,
                        BrandName = brand.name,
                        ProductName = pro.Name,
                        stok = brand.name,
                        ProductPrice = pro.Price

                    }
                ).Where(x => x.ProductName.Contains(brandsOfProduct) && x.ProductPrice >= minValue && x.ProductPrice <= maxValue).GroupBy(x => x.BrandName).Select(x => new { stok = x.Count(), x.FirstOrDefault().BrandId, x.FirstOrDefault().ProductName, x.FirstOrDefault().BrandName, x.FirstOrDefault().ProductPrice }).ToList();

                foreach (var a in col)
                {

                    productBrand = new ProductBrand
                    {
                        productName = a.ProductName,
                        brandId = a.BrandId,
                        brandName = a.BrandName,
                        stok = a.stok,
                        Price = a.ProductPrice

                    };
                    productBrands.Add(productBrand);
                }
                return productBrands.ToList();
            }
        }
    }
}