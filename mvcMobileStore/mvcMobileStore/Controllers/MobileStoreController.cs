using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcMobileStore.Models;

namespace mvcMobileStore.Controllers
{
    public class MobileStoreController : Controller
    {
        // GET: MobileStore
        dbQLMobileDataContext data = new dbQLMobileDataContext();
        private List<SanPham> LaySP(int count)
        {
            return data.SanPhams.OrderByDescending(a => a.MASP).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var SPMoi = LaySP(9);
            return View(SPMoi);
        }   
        
        public ActionResult Details(string id)
        {
            var sanpham = from sp in data.SanPhams
                          where sp.MASP == id
                          select sp;
            return View(sanpham.Single());
        }
    }
}