using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Bll.Abstract;
using ETicaret.Bll.Concrete;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;
using ETicaret.MVCUI.Models;
using System.Drawing;

namespace ETicaret.MVCUI.Controllers
{
    public class ProductController : Controller
    {
        IProductBll _productBll = new ProductBll(new ProductDal());
        ICommentBll _commentBll = new CommentBll(new CommentDal());
        IProductReviewBll _productReviewBll = new ProductReviewBll(new ProductReviewDal());
        IProductSpesificationBll _productSpesificationBll = new ProductSpesificationBll(new ProductSpesificationDal());


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

        //todo yorum ekleme çalışmıyor.
        [HttpPost]
        public ActionResult AddComment(Comment com)
        {
            try
            {
                if (com.Text != null)
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
        //todo yorum boş gönderildiğinde hata verdirilmeli
        [HttpPost]
        public ActionResult Review(int? voteCount, int productId, string text)
        {
            try
            {
                string hata = "";
                Member loginMember = (Member)Session["Login"];
                ProductReview review = new ProductReview();
                review.productId = productId;
                if (voteCount != null || !string.IsNullOrEmpty(text))
                {
                    review.YildizSayisi = voteCount.Value;
                    review.text = text;
                    review.customerId = loginMember.Id;

                    _productReviewBll.Add(review);
                    return RedirectToAction("Detay", new { id = productId });

                }
                else
                {
                    hata = "Yıldız Değerlendirme ve Yorum Satırı Boş Geçilemez!";
                    ViewBag.YorumHata = hata;
                }

                return RedirectToAction("Detay", new { id = productId }); ;

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
            //todo ürün ekleme view değiştirilecek. ürün ekledikten sonra redirecttoAction diyerek AddProductModelOptions actionına gönderip Özellikleri oradan yapacağız. Tek sayfada sayfa gizle aç işlemini iptal edeceğiz.

            try
            {
                Product isValidProduct = _productBll.GetOne(x => x.Id == pro.Id);

                if (isValidProduct == null)
                {
                    pro.AddedDate = DateTime.Now;
                    pro.ModifiedDate = DateTime.Now;
                    pro.ProductTypeID = 1;
                    pro.IsContinued = true;
                    bool resultAdd = _productBll.Add(pro);

                    if (resultAdd)
                    {

                        return RedirectToAction("AddProductOptions", new { id = pro.Id });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    isValidProduct.ModifiedDate = DateTime.Now;
                    isValidProduct.Caption = pro.Caption;
                    isValidProduct.ProductBrandID = pro.ProductBrandID;
                    isValidProduct.Category_Id = pro.Category_Id;
                    ViewBag.kayitEdilen = pro.Id;
                    isValidProduct.Description = pro.Description;
                    isValidProduct.Name = pro.Name;
                    isValidProduct.Price = pro.Price;

                    bool resultUpdate = _productBll.Update(isValidProduct);
                    if (resultUpdate)
                    {

                        return RedirectToAction("AddProductOptions", new { id = isValidProduct.Id });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }


            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult AddProductOptions(int? id)
        {


            Product product = _productBll.GetOne(x => x.Id == id.Value);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public JsonResult AddProductOptions(int? id, string dizi)
        {
            try
            {
                ProductSpesification ps = new ProductSpesification();
                Product pro = _productBll.GetOne(x => x.Id == id);
                if (pro != null)
                {
                    string[] kes = dizi.Split('-');

                    if (kes.Length > 0)
                    {
                        for (int i = 0; i < ((kes.Length - 1) / 2); i += 2)
                        {
                            if (kes[i].Trim() != "")
                            {
                                ps.ProductId = pro.Id;
                                ps.SpeCaption = kes[i];
                                ps.SpeDescription = kes[i + 1];
                                _productSpesificationBll.Add(ps);
                            }
                        }
                    }

                    return Json("success", JsonRequestBehavior.AllowGet);
                }

                return Json("error", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }


        public ActionResult AddProductPicture(int id)
        {
            Product pro = _productBll.GetOne(x => x.Id == id);
            return View(pro);
        }

        [HttpPost]
        public ActionResult AddProductPicture(int id, List<HttpPostedFileBase> file)
        {
            IProductPictureBll _productPictureBll = new ProductPictureBll(new ProductPictureDal());
            string uploadPath = ConfigurationManager.AppSettings["UploadPath"];
            string uploadMapPath = Server.MapPath(uploadPath);
            if (Directory.Exists(uploadMapPath) == false)
            {
                Directory.CreateDirectory(uploadMapPath);
            }

            string coverPicPath = ConfigurationManager.AppSettings["CoverUploadPath"];
            string coverMapPath = Server.MapPath(coverPicPath);

            if (Directory.Exists(coverMapPath) == false)
            {
                Directory.CreateDirectory(coverMapPath);
            }

            string ThumpPath = ConfigurationManager.AppSettings["ThumpNailUploadPath"];
            string ThumpMapPath = Server.MapPath(ThumpPath);
            if (Directory.Exists(ThumpMapPath) == false)
            {
                Directory.CreateDirectory(ThumpMapPath);
            }
            
            string ThumpExtention = file[0].ContentType.Split('/')[1];//ilk resmi Thumpnail yapmak için 0'ıncı indexi aldım.
            string ThumpfileName = "f-" + id + "-" + Guid.NewGuid() + "." + ThumpExtention;
            string ThumpFullFileUrl = ThumpMapPath + "/" + ThumpfileName;
            string ForDbFullFileUrlThumpnail = ThumpPath + "/" + ThumpfileName;
            Image orjThumpImage = Image.FromStream(file[0].InputStream);
            Bitmap ThumpNail = new Bitmap(orjThumpImage, 255, 271);
            ThumpNail.Save(ThumpFullFileUrl);
            Product product = _productBll.GetOne(x => x.Id == id);
            if (product != null)
            {
                string replaceLanda = ForDbFullFileUrlThumpnail.Replace("~", "..");
                product.ThumpNailPicture = replaceLanda;
                _productBll.Update(product);
            }

            foreach (HttpPostedFileBase httpPostedFileBase in file)
            {
                string ext = httpPostedFileBase.ContentType.Split('/')[1];
                string fileName = "f-" + id + "-" + Guid.NewGuid() + "." + ext;
                string forDbFullFileUrlForCoverPic = coverPicPath + "/" + fileName;
                string CoverFullFileName = coverMapPath + "/" + fileName;
                Image orjImage = Image.FromStream(httpPostedFileBase.InputStream);
                Bitmap CoverPic = new Bitmap(orjImage, 540, 584);
                CoverPic.Save(CoverFullFileName);
                ProductPicture pp = new ProductPicture();
                string replaceLanda = forDbFullFileUrlForCoverPic.Replace("~", "../..");
                pp.PicPath = replaceLanda;
                if (product!=null)
                {
                    pp.ProductID = product.Id;
                    _productPictureBll.Add(pp);
                }
               
               
            }
            //file.SaveAs(fullFileName);
            return RedirectToAction("AddProduct");

        }
    }
}