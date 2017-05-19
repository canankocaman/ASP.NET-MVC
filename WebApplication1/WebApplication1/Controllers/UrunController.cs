using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        SatisContext veritabani = new SatisContext();
        public ActionResult Index()
        {
           List<Urun> urunler = veritabani.Urunler.ToList();
            
            return View(urunler);
        }

        public ActionResult kategori(int id)
        {
            string kategoriAdi = (from k in veritabani.Kategoriler where k.Id == id select k.Ad).FirstOrDefault();

            ViewBag.Title = kategoriAdi + " kategorisidneki ürünler";
            ViewBag.Id = id;

            List<Urun> urunler = (from u in veritabani.Urunler where u.KategoriId == id select u).ToList();

            return View(urunler);
        }

        public ActionResult Detay(int id)
        {
            Urun ürün = (from u in veritabani.Urunler where u.Id == id select u).FirstOrDefault();

            return View(ürün);
        }

        public ActionResult yeni()
        {
            var kategoriler = veritabani.Kategoriler.ToList().Select(k => new SelectListItem
            {

                Selected = false,
                Text = k.Ad,
                Value = k.Id.ToString()

            }).ToList();

            ViewBag.Kategoriler = kategoriler;
            
            return View();
        }

        [HttpPost]
        public ActionResult yeni(Urun urun)
        {
            veritabani.Urunler.Add(urun);
            veritabani.SaveChanges();
            return RedirectToAction("Kategori", new { id = urun.KategoriId });
        }

        public ActionResult KategoriyeYeniUrun(int id)
        {
            var kategoriAd = (from k in veritabani.Kategoriler where k.Id == id select k.Ad).FirstOrDefault();
            ViewBag.KategoriAd = kategoriAd;
            ViewBag.KategoriId = id;

            return View();
        }

        [HttpPost]
        public ActionResult KategoriyeYeniUrun(Urun urun, int id)
        {
            urun.KategoriId = id;
            veritabani.Urunler.Add(urun);
            veritabani.SaveChanges();
            return RedirectToAction("Kategori", new { id = urun.KategoriId });
        }

        public ActionResult Duzenle(int id)
        {
            //tüm kategori bilgisini çektim(bilgisayar,televizyon,cep telefonu)
            var kategoriler = veritabani.Kategoriler.ToList().Select(k => new SelectListItem
            {
                Selected = false,
                Text = k.Ad,
                Value = k.Id.ToString()
            }).ToList();

            // Bu bilgileri view'a gönderdim
            ViewBag.Kategoriler = kategoriler;

            //parametredeki id ile aynı Id ye sahip ürün bilgisini çekip view'a gönderdim
            Urun urun = (from u in veritabani.Urunler where u.Id == id select u).FirstOrDefault();

            return View(urun);
        }

        [HttpPost]
        public ActionResult Duzenle(Urun urun)
        {
            Urun veritabanindakiürün = (from u in veritabani.Urunler where u.Id == urun.Id select u).FirstOrDefault();

            veritabanindakiürün.Ad = urun.Ad;
            veritabanindakiürün.KategoriId = urun.KategoriId;
            veritabanindakiürün.Fiyat = urun.Fiyat;
            veritabanindakiürün.Stok = urun.Stok;

            veritabani.SaveChanges();
            return RedirectToAction("Detay",new {id = urun.Id});
        }

        public ActionResult Sil(int id)
        {
            Urun urun = (from u in veritabani.Urunler where u.Id == id select u).FirstOrDefault(); 
            return View(urun);
        }


        [HttpPost,ActionName("Sil")]
        public ActionResult Sil_urun(int id)
        {
            Urun silinecek_urun = (from u in veritabani.Urunler where u.Id == id select u).FirstOrDefault();

            int kategoriId = silinecek_urun.KategoriId;

            veritabani.Urunler.Remove(silinecek_urun);
            veritabani.SaveChanges();

            return RedirectToAction("");
        }

    }
}