using System.ComponentModel.DataAnnotations;

namespace KullaniciListe.Data
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? KullaniciSoyadi { get; set; }
        public int KullaniciYas { get; set; }
        public string? KullaniciPozisyon { get; set; }
        public string? KullaniciNumara { get; set; }
        public string? KullaniciMail { get; set; }
    }
}
// bu kod, Kullanici modelini tanımlar ve gerekli özellikleri içerir.