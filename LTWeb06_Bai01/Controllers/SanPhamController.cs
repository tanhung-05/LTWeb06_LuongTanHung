using LTWeb06_Bai01.Models;
using LTWeb06_Bai01.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace LTWeb06_Bai01.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult SanPhamTheoLoai(string id)
        {
            SanPhamService spService = new SanPhamService();
            return View(spService.GetSanPhamByLoai(id));
        }

        public ActionResult SanPhamTheoId(string id)
        {
            SanPhamService spService = new SanPhamService();
            return View(spService.GetSanPhamById(id));
        }

        [HttpGet]
        public ActionResult Search(string maLoai, decimal? giaTu, decimal? giaDen)
        {
            LoaiService loaiService = new LoaiService();
            var dsLoai = loaiService.GetLoaiAll();
            List<SelectListItem> loaiList = new List<SelectListItem>();
            loaiList.Add(new SelectListItem { Text = "--Tất cả--", Value = "" });
            foreach (var l in dsLoai)
            {
                loaiList.Add(new SelectListItem
                {
                    Text = l.TenLoai,
                    Value = l.MaLoai,
                    Selected = (maLoai == l.MaLoai)
                });
            }
            ViewBag.LoaiList = loaiList;
            SanPhamService service = new SanPhamService();
            List<SanPham> dsSanPham = service.SearchSanPham(maLoai, giaTu, giaDen);

            return View(dsSanPham);
        }
    }
}