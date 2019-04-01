using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class ProductBll:IProductBll
    {

        private IProductDal _productDal;
        public ProductBll(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> ListThem(Expression<Func<Product,bool>>filter)
        {
            List<Product> products = _productDal.ListThem();
            return products;
       
        }

        public Product GetOne(Expression<Func<Product, bool>> filter)
        {
            return _productDal.GetOne(filter);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(int id)
        {
            var deleteObject = _productDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                _productDal.Delete(deleteObject);
            }
            
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public List<Product> ListAccordingToCategory(int? id)
        {
            if (id>0)
            {
                 List<Product> products= _productDal.ListThem(x => x.Category_Id == id);
            return products;
            }
            else
            {
                return null;
            }
        }

        public List<Product> FilterProduct(string id)
        {
            return _productDal.ListThem(x => x.Name.Contains(id)).ToList();
        }

        public List<Product> PriceFilter(string search,decimal down, decimal up)
        {
            if (up==10000)
            {
                return _productDal.ListThem(x => x.Name.Contains(search)&& x.Price >= down);
            }
            else
            {
                return _productDal.ListThem(x => x.Name.Contains(search) && x.Price >= down && x.Price <= up);
            }
         
        }

        public bool AddProductBool(Product product)
        {
            return _productDal.AddProductBool(product);
        }
    }
}