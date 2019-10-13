using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Bll.Abstract;
using ETicaret.Bll.Concrete;
using ETicaret.Dal.Concrete;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;
using ETicaret.MVCUI.Models;

namespace ETicaret.MVCUI.Controllers
{
    public class ProductController : Controller
    {
        IProductBll _productBll = new ProductBll(new ProductDal());
        ICommentBll _commentBll = new CommentBll(new CommentDal());
        IProductReviewBll _productReviewBll = new ProductReviewBll(new ProductReviewDal());
        IProductSpesificationBll _productSpesificationBll = new ProductSpesificationBll(new ProductSpesificationDal());
        IProductPictureBll _productPictureBll = new ProductPictureBll(new ProductPictureDal());

        // GET: Product
        int pageSize = 5;

        public ActionResult Detay(int id, int? page, int? commentPage)
        {
            double five = (double)_productReviewBll.AccordingToStarCount(5, id).Count;
            double four = (double)_productReviewBll.AccordingToStarCount(4, id).Count;
            double three = (double)_productReviewBll.AccordingToStarCount(3, id).Count;
            double two = (double)_productReviewBll.AccordingToStarCount(2, id).Count;
            double one = (double)_productReviewBll.AccordingToStarCount(1, id).Count;
            double totalReview = (double)_productReviewBll.AccordingToProductList(id).Count;
            double avg = ((5 * five) + (4 * four) + (3 * three) + (2 * two) + (1 * one)) / totalReview;
            ViewBag.fiveStars = five;
            ViewBag.fourStars = four;
            ViewBag.threeStars = three;
            ViewBag.twoStars = two;
            ViewBag.oneStars = one;
            ViewBag.TotalReviews = totalReview;
            ViewBag.avg = avg;

            var product = _productBll.GetOne(x => x.Id == id);
            var productComments = _commentBll.ListAccordingToProductId(id).OrderByDescending(x => x.AddedDate).Take(pageSize).ToList();
            var productReviews = _productReviewBll.AccordingToProductList(id).Take(pageSize).ToList();

            if (!page.HasValue && !commentPage.HasValue)
            {


                ProductAndReviews productAndReviews = new ProductAndReviews
                {
                    Product = product,
                    ProductReviews = productReviews,
                    Comments = productComments

                };
                return View(productAndReviews);
            }
            if (commentPage.HasValue)
            {

                int pageIndex = pageSize * commentPage.Value;
                var skippedComments = _commentBll.ListAccordingToProductId(id).OrderByDescending(x => x.AddedDate).Skip(pageIndex).Take(pageSize).ToList();
                return PartialView("_CommentList", skippedComments);


            }
            else
            {
                int pageIndex = pageSize * page.Value;

                var listedReviews = _productReviewBll.AccordingToProductList(id).Skip(pageIndex).Take(pageSize).ToList();
                return PartialView("_ReviewList", listedReviews);
            }




        }


        //todo yorum cevapları yapılacak
        //[HttpPost]
        //public void CommentRepplies(int id)
        //{
        //    var comment = _commentBll.ListThem(x => x.ToWhoId == id);
        //    if (comment!=null)
        //    {
        //        ViewBag.commentRepplies = comment;
        //    }

        //}
        [HttpPost]
        public ActionResult AddComment(Comment com)
        {
            try
            {
                if (com.Text!=null)
                {
                    
                Member member = (Member)Session["Login"];
                com.AddedDate = DateTime.Now;
                com.Member_Id = member.Id;
                _commentBll.Add(com);
                }

            }
            catch (Exception e)
            {
                //todo, hata mesajı verdirilecek
                return RedirectToAction("Detay", new { id = com.Product_Id });
            }
            return RedirectToAction("Detay", new { id = com.Product_Id });
        }
        [HttpPost]
        public ActionResult Review(int? voteCount, int productId, string text)
        {
            try
            {

                Member loginMember = (Member)Session["Login"];
                ProductReview review = new ProductReview();
                review.productId = productId;
                if (voteCount!=null)
                {
                    review.YildizSayisi = voteCount.Value;
                    review.text = text;
                    review.customerId = loginMember.Id;

                    _productReviewBll.Add(review);
                    return RedirectToAction("Detay", new { id = productId });

                }
                return RedirectToAction("Detay", new { id = productId });
                
            }
            catch (Exception e)
            {

                return RedirectToAction("Index", "Home");
            }


        }

        public ActionResult AddProduct()
        {
            ICategoryBll _categoryBll = new CategoryBll(new CategoryDal());
            IBrandBll _brandBll = new BrandBll(new BrandDal());
            //todo kategoriler parent-child kategoriye çevrilince düzenlenecek.


            AddProductModel addProduct = new AddProductModel
            {
                Brands = _brandBll.ListThem(),
                Categories = _categoryBll.ListThem()
            };

            return View(addProduct);
        }
        [HttpPost]
        public ActionResult AddProduct(Product pro)
        {

            try
            {
                Product isValidProduct=_productBll.GetOne(x => x.Id == pro.Id);
                
                if (isValidProduct==null)
                {
                    pro.AddedDate = DateTime.Now;
                    pro.ModifiedDate = DateTime.Now;
                    pro.ProductTypeID = 1;
                    pro.IsContinued = true;
                    _productBll.Add(pro);
                    ViewBag.kayitEdilen = pro.Id;
                    
                }
               
                else
                {

                    isValidProduct.ModifiedDate = DateTime.Now;


                    _productBll.Update(isValidProduct);
                }
                
                
                return Json(new{
                    sonuc=1,pro=pro.Id
                });
            }
            catch (Exception e)
            {
                return Json(0);
            }




        }

        [HttpPost]
        public ActionResult AddProductModelOptions(string dizi, int proId)
        {
            ProductSpesification ps = new ProductSpesification();
            try
            {


                Product pro = _productBll.GetOne(x => x.Id == proId);
               
                string[] kes = dizi.Split('-');

                for (int i = 0; i < kes.Length; i++)
                {
                    if (kes[i] != "")
                    {
                        ps.ProductId = pro.Id;
                        ps.SpeCaption = kes[0];
                        ps.SpeDescription = kes[1];
                        _productSpesificationBll.Add(ps);
                    }
                }
                return Json(1);
                }
           
            catch (Exception e)
            {
                return Json(0);
            }

        }
    }
}