using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Bll.Abstract;
using ETicaret.Bll.Concrete;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;

namespace ETicaret.MVCUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        IMemberBll _memberBll=new MemberBll(new MemberDal());

        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(Member member)
        {
            try
            {
                Member logOne = _memberBll.GetOne(x => x.Email == member.Email && x.Password == member.Password);
                if (logOne!=null)
                {
                    Session["Login"] = logOne;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.login = "Email ya da Şifre Yanlış";
                }
            }
            catch (Exception e)
            {
                ViewBag.login = e.Message;
                return View();
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Member member)
        {
            try
            {
                member.AddedDate = DateTime.Now;
                member.MemberType = 4;
                var emailCheck = _memberBll.GetOne(x => x.Email == member.Email);
                if (emailCheck!=null)
                {
                    ViewBag.register = "Böyle Bir Email Zaten Kayıtlıdır!";
                    return View();
                }
                else
                {
                    _memberBll.Add(member);
                    return RedirectToAction("Login");
                }
                
            }
            catch (Exception e)
            {
                ViewBag.register = e.Message;
                return RedirectToAction("Register");
            }

           
        }

        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Login");
        }
    }
}