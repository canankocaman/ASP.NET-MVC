using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }

        [DisplayName("Ürün Adı")]
        public string Ad { get; set; }
        public double Fiyat { get; set; }

        [DisplayName("Stok Miktarı")]
        public int Stok { get; set; }
        public virtual Kategori kategori { get; set; }
    }
}