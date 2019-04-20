using ETicaret.Entities.Models;

namespace ETicaret.Dal.Abstract
{
    public interface IProductDal:IRepositoryBase<Product>
    {
        bool AddProductBool(Product product);
    }
}