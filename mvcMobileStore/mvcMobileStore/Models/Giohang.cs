using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcMobileStore.Models;

namespace mvcMobileStore.Models
{
    public class Giohang
    {
        dbQLMobileDataContext data = new dbQLMobileDataContext();
        public string iMasp { get; set; }
        public string iMancc { get; set; }
        public string iManpp { get; set; }
        public string iTensp { get; set; }
        public string iAnhsp { get; set; }
        public int iSoluong { get; set; }
        public Double iDongia { get; set; }
        public Double iThanhtien 
        {
            get { return iSoluong * iDongia; } 
        }

        public Giohang(string Masp)
        {
            iMasp = Masp;
            SanPham sp = data.SanPhams.Single(n => n.MASP == iMasp);
            iMancc = sp.MANCC;
            iManpp = sp.MaNPP;
            iTensp = sp.TENSP;
            iAnhsp = sp.AnhSP;
            iDongia = double.Parse(sp.GiaBan.ToString());
            iSoluong = 1;
        }
    }
}