using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Bll.Abstract;
using ETicaret.Bll.Concrete;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;
using ETicaret.MVCUI.Models;
using PagedList;

namespace ETicaret.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IProductBll _productBll =new ProductBll(new ProductDal());
        IOrderDetailBll _orderDetail =new OrderDetailBll(new OrderDetailDal());
        ICategoryBll _categoryBll=new CategoryBll(new CategoryDal());
        public ActionResult Index(int? pageNo)
        {
            int page = pageNo ?? 1;
            
            var orderedProducts = _orderDetail.MostOrderList();
            IPagedList<Product> latestAddedProduct = _productBll.ListThem().OrderByDescending(x => x.AddedDate).ToPagedList(page,24);
            var categories = _categoryBll.ListThem().Take(4).ToList();
            
            HomeIndexKarmaModel homeIndexKarmaModel = new HomeIndexKarmaModel
            {
                OrderDetails = orderedProducts,
                LatestAddedProducts = latestAddedProduct,
                Categories = categories,
            };
           
            
                
                return View(homeIndexKarmaModel);
            
            
            
        }

      
    }
}