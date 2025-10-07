using LTWeb06_Bai01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb06_Bai01.Controllers
{
    public class LoaiController : Controller
    {
        // GET: Loai
        public ActionResult _Menu()
        {
            LoaiService loaiService = new LoaiService();
            return PartialView(loaiService.GetLoaiAll());
        }
    }
}