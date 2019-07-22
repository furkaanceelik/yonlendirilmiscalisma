using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FurkanCelik.Models
{
    public class DersSecimi
    {
        public int Id { get; set; }

        [DisplayName("Ders Adı")]
        public string DersAdi { get; set; }

        [DisplayName("Öğrenci Seçimi")]
        public bool OgrenciSecmisMi { get; set; }

        [DisplayName("Öğretmen Onayı")]
        public bool OgretmenOnayi { get; set; }

    }
}
