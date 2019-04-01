using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ETicaret.Bll.Abstract;
using ETicaret.Bll.Concrete;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;
using ETicaret.MVCUI.Models;
using PagedList;

namespace ETicaret.MVCUI.Controllers
{
    public class FilterController : Controller
    {
        IProductBll _productBll = new ProductBll(new ProductDal());
        IBrandBll _brandBll=new BrandBll(new BrandDal());
        FilterPage _filterPage;
        // GET: Filter

        public ActionResult Index(string searchh, int? filter, int? pageNo, decimal? down, decimal? up)
        {
                ViewBag.istek = searchh;
                int pageIndex = pageNo ?? 1;
            
            IPagedList<Product> filteredProduct = _productBll.FilterProduct(searchh).ToPagedList(pageIndex,24);
            List<ProductBrand> brands = _brandBll.BrandsOfProduct(searchh, down, up);
            if (!pageNo.HasValue &&!filter.HasValue)
            {
                if (down.HasValue && up.HasValue)
                {
                    var take = _productBll.PriceFilter(searchh, down.Value, up.Value).ToPagedList(pageIndex, 24);
                    var brand = brands;
                    _filterPage = new FilterPage { Products = take, BrandsOfProduct = brand };
                    return PartialView("_Filter",_filterPage);

                }
                
                    if (!string.IsNullOrEmpty(searchh))
                    {
                        _filterPage = new FilterPage { Products = filteredProduct, BrandsOfProduct = brands };
                        return View(_filterPage);
                    }
                    else
                    {
                      
                        IPagedList<Product> noneFilteredProduct = _productBll.ListThem().ToPagedList(pageIndex,24);
                        _filterPage = new FilterPage { Products = noneFilteredProduct, BrandsOfProduct = brands };
                        return View(_filterPage);
                    }
                
            }
            else
            {
                string istek = (string)ViewBag.istek;
                try
                {
                    if (down.HasValue && up.HasValue && !filter.HasValue)
                    {
                        var take = _productBll.PriceFilter(searchh, down.Value, up.Value).ToPagedList(pageIndex, 24);
                        var brand = brands;
                        _filterPage = new FilterPage { Products = take, BrandsOfProduct = brand };
                        return PartialView("_Filter", _filterPage);

                    }
           
                
                    switch (filter)
                    {

                        case 1:
                            if (!down.HasValue && !up.HasValue)
                            {
                                IPagedList<Product> orderbyProduct = _productBll.FilterProduct(istek).OrderBy(x => x.Price).ToPagedList(pageIndex, 24);
                                _filterPage = new FilterPage
                                {
                                    Products = orderbyProduct,
                                    BrandsOfProduct = brands
                                };
                                return PartialView("_Filter", _filterPage); break;
                            }
                            else
                            {
                                IPagedList<Product> orderbyProduct = _productBll.PriceFilter(istek, down.Value, up.Value).OrderBy(x => x.Price).ToPagedList(pageIndex, 24);
                                _filterPage = new FilterPage
                                {
                                    Products = orderbyProduct,
                                    BrandsOfProduct = brands
                                };

                                return PartialView("_Filter", _filterPage); break;
                            }

                        case 2:
                            if (!down.HasValue && !up.HasValue)
                            {
                                IPagedList<Product> latestProduct = _productBll.FilterProduct(istek).OrderByDescending(x => x.Price).ToPagedList(pageIndex, 24);
                                _filterPage = new FilterPage
                                {
                                    Products = latestProduct,
                                    BrandsOfProduct = brands
                                };
                                return PartialView("_Filter", _filterPage); break;
                            }
                            else
                            {
                                IPagedList<Product> descendingProduct = _productBll.PriceFilter(istek, down.Value, up.Value).OrderByDescending(x => x.Price).ToPagedList(pageIndex, 24);
                                _filterPage = new FilterPage
                                {
                                    Products = descendingProduct,
                                    BrandsOfProduct = brands
                                };

                                return PartialView("_Filter", _filterPage); break;
                            }

                           
                        case 3:
                            if (!down.HasValue && !up.HasValue)
                            {
                                IPagedList<Product> latestProduct = _productBll.FilterProduct(istek).OrderByDescending(x => x.AddedDate).ToPagedList(pageIndex, 24);
                                _filterPage = new FilterPage
                                {
                                    Products = latestProduct,
                                    BrandsOfProduct = brands
                                };
                                return PartialView("_Filter", _filterPage); break;
                            }
                            else
                            {
                                IPagedList<Product> latestProduct = _productBll.PriceFilter(istek, down.Value, up.Value).OrderByDescending(x => x.AddedDate).ToPagedList(pageIndex, 24);
                                _filterPage = new FilterPage
                                {
                                    Products = latestProduct,
                                    BrandsOfProduct = brands
                                };


                                return PartialView("_Filter", _filterPage); break;
                            }
                          
                            
                          
                        default:

                            IPagedList<Product> noneFilteredProduct = _productBll.ListThem().ToPagedList(pageIndex, 24);
                            _filterPage = new FilterPage
                            {
                                Products = noneFilteredProduct

                            };
                            return PartialView("_Filter", _filterPage);
                    }
                }
                catch

                (Exception EX_NAME)
                {


                    IPagedList<Product> noneFilteredProduct = _productBll.ListThem().ToPagedList(pageIndex, 24);
                    _filterPage = new FilterPage
                    {
                        Products = noneFilteredProduct

                    };
                    return PartialView("_Filter", _filterPage);

                }

               
           
            }

           

        }

        public ActionResult BrandList(string search, decimal? down, decimal? up)
        {
            List<ProductBrand> brands = _brandBll.BrandsOfProduct(search, down, up);
            _filterPage= new FilterPage {BrandsOfProduct = brands};
            return PartialView("_BrandFilter", _filterPage);
        }

    }
}