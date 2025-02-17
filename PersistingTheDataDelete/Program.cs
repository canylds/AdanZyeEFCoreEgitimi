using Microsoft.EntityFrameworkCore;

namespace PersistingTheDataDelete;

internal class Program
{
    static async Task Main(string[] args)
    {
        ETicaretContext context = new ETicaretContext();

        #region Veri Nasıl Silinir?
        //Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 5);
        //context.Urunler.Remove(urun);
        //await context.SaveChangesAsync();
        #endregion

        #region Silme İşleminde ChangeTracker'ın Rolü
        //ChangeTracker, context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır. Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemler neticesinde update yahut delete sorgularının oluşturulacağı anlaşılır!
        #endregion

        #region Takip Edilmeyen Nesneler Nasıl Silinir?
        //Urun urun = new Urun()
        //{
        //    Id = 2
        //};
        //context.Urunler.Remove(urun);
        //await context.SaveChangesAsync();
        #region EntityState İle Silme İşlemi
        //Urun urun = new Urun()
        //{
        //    Id = 1
        //};
        //context.Entry(urun).State = EntityState.Deleted;
        //await context.SaveChangesAsync();
        #endregion
        #endregion

        #region Birden Fazla Veri Silinirken Nelere Dikkat Edilmelidir?
        #region SaveChanges'ı Verimli Kullanalım

        #endregion
        #region RemoveRange
        List<Urun> urunler = await context.Urunler.Where(u => u.Id >= 7 && u.Id <= 9).ToListAsync();
        context.Urunler.RemoveRange(urunler);
        await context.SaveChangesAsync();
        #endregion
        #endregion
    }
}

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=ETicaretDB;Trusted_Connection=True");
    }
}

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
}
