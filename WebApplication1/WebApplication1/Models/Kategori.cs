using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        public string Ad { get; set; }
        public virtual ICollection<Urun> Urunler { get; set; }
    }
}