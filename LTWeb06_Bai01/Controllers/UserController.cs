using LTWeb06_Bai01.Models;
using LTWeb06_Bai01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb06_Bai01.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string SoDienThoai, string MatKhau, string returnUrl)
        {
            var userService = new UserService();
            var user = userService.FindUserBySDT(SoDienThoai);

            if (user != null && user.MatKhau.Trim() == MatKhau.Trim())
            {
                Session["User"] = user;

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Sai số điện thoại hoặc mật khẩu";
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public ActionResult HoaDonKhachHang(string id)
        {
            HoaDonService hdService = new HoaDonService();
            return View(hdService.GetHoaDonByUser(id));
        }

        public ActionResult CTHoaDon(string id)
        {
            HoaDonService hoaDonService = new HoaDonService();
            return View(hoaDonService.GetCTHoaDonByHoaDon(id));
        }
    }
}