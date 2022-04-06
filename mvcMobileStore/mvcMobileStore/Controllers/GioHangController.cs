using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcMobileStore.Models;

namespace mvcMobileStore.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        dbQLMobileDataContext data = new dbQLMobileDataContext();
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            { 
                lstGiohang = new List<Giohang>();
                Session["Giohang"]=lstGiohang;
            }
            return lstGiohang;
        }

        public ActionResult ThemGiohang(string iMasanp, string URL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sp = lstGiohang.Find(n => n.iMasp == iMasanp);
            if(sp == null)
            {
                sp = new Giohang(iMasanp);
                lstGiohang.Add(sp);
                return Redirect(URL);
            }else
            {
                sp.iSoluong++;
                return Redirect(URL);
            }
        }

        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }

        private double TongTien()
        {
            double iTongTien = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if(lstGiohang != null)
            {
                iTongTien = lstGiohang.Sum(n => n.iThanhtien);
            }
            return iTongTien;
        }

        public ActionResult GioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            if(lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "MobileStore");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();  
            return View(lstGiohang);
        }

        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }
    }
}