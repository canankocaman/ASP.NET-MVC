using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class SatisInitializer:
    System.Data.Entity.CreateDatabaseIfNotExists<SatisContext>

    {
        protected override void Seed(SatisContext context)
        {
            var kategoriBilgisayar = new Kategori { Ad = "Bilgisayar" };
            var kategoriCepTelefon = new Kategori { Ad = "Cep Telefonu" };
            var kategoriTelevizyon = new Kategori { Ad = "Televizyon" };

            context.Kategoriler.Add(kategoriBilgisayar);
            context.Kategoriler.Add(kategoriCepTelefon);
            context.Kategoriler.Add(kategoriTelevizyon);
            context.SaveChanges();

            List<Urun> urunler = new List<Urun>
            {
                new Urun { Ad="Notebook", Fiyat=2000, KategoriId=kategoriBilgisayar.Id, Stok=300 }, 
                new Urun { Ad="Tablet PC", Fiyat=800, KategoriId=kategoriBilgisayar.Id, Stok=450 },
                new Urun { Ad="Masaüstü", Fiyat=1500, KategoriId=kategoriBilgisayar.Id, Stok=150 },
                new Urun { Ad="Ultrabook", Fiyat=3000, KategoriId=kategoriBilgisayar.Id, Stok=85 },
                new Urun { Ad="Smartphone", Fiyat=2000, KategoriId=kategoriCepTelefon.Id, Stok=1000},
                new Urun { Ad="Tabphone", Fiyat=3000, KategoriId=kategoriCepTelefon.Id, Stok=50 },
                new Urun { Ad="Led TV", Fiyat=3500, KategoriId=kategoriTelevizyon.Id, Stok=50 },
                new Urun { Ad="LCD TV", Fiyat=1100, KategoriId=kategoriTelevizyon.Id, Stok=30 },
                new Urun { Ad="Plazma TV", Fiyat=2250, KategoriId=kategoriTelevizyon.Id, Stok=20 }
            };

            urunler.ForEach(urun => context.Urunler.Add(urun));
            context.SaveChanges();
        }
    }
}