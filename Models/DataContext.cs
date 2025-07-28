using Microsoft.EntityFrameworkCore;

namespace KullaniciListe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Kullanici> kullanicilar => Set<Kullanici>();
    }
}
//DataContext sınıfı, Entity Framework Core kullanarak veritabanı ile etkileşimde bulunmak için kullanılır.