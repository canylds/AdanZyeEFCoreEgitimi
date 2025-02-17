using Microsoft.EntityFrameworkCore;

namespace PersistingTheData;

internal class Program
{
    static async Task Main(string[] args)
    {
        #region Veri Nasıl Eklenir?
        //ETicaretContext context = new ETicaretContext();
        //Urun urun = new Urun()
        //{
        //    UrunAdi = "A ürünü",
        //    Fiyat = 1000
        //};
        #region context.AddAsync Fonksiyonu
        //await context.AddAsync(urun);
        #endregion
        #region context.DbSet.AddAsync Fonksiyonu
        //await context.Urunler.AddAsync(urun);
        #endregion
        //await context.SaveChangesAsync();
        #endregion
        #region SaveChanges Nedir?
        //SaveChanges; insert, update, delete sorgularını oluşturup bir transacton eşliğinde veritabanına gönderip execute eden fonksiyondur. Eğer ki oluşturulan sorgulardan herhangi biri başarısız olursa tüm işlemleri geri alır (rollback)
        #endregion
        #region EF Core Açısından Bir Verinin Eklenmesi Gerektiği Nasıl Anlaşılıyor?
        //ETicaretContext context = new ETicaretContext();
        //Urun urun = new Urun()
        //{ 
        //    UrunAdi = "B Ürünü",
        //    Fiyat = 2000
        //};

        //Console.WriteLine(context.Entry(urun).State);

        //await context.AddAsync(urun);

        //Console.WriteLine(context.Entry(urun).State);

        //await context.SaveChangesAsync();

        //Console.WriteLine(context.Entry(urun).State);
        #endregion
        #region Birden Fazla Veri Eklerken Nelere Dikkat Edilmelidir?
        //ETicaretContext context = new ETicaretContext();
        //Urun urun1 = new Urun()
        //{
        //    UrunAdi = "F Ürünü",
        //    Fiyat = 6000
        //};
        //Urun urun2 = new Urun()
        //{
        //    UrunAdi = "G Ürünü",
        //    Fiyat = 7000
        //};
        //Urun urun3 = new Urun()
        //{
        //    UrunAdi = "H Ürünü",
        //    Fiyat = 8000
        //};

        //await context.AddAsync(urun1);
        //await context.SaveChangesAsync();

        //await context.AddAsync(urun2);
        //await context.SaveChangesAsync();

        //await context.AddAsync(urun3);
        //await context.SaveChangesAsync();

        //await context.SaveChangesAsync();
        #endregion
        #region SaveChanges'ı Verimli Kullanalım!
        //SaveChanges fonksiyonu her tetiklendiğinde bir transaction oluşituracağından dolayı EF Core ile yapılan her bir işleme özel kullanmaktan kaçınmalıyız! Çünkü her işleme özel transaction veritaanı açısından ekstradan maliyet demektir. O yüzden mümkün mertebe tüm işlemlerimizi tek bir transaction eşliğinde veritabanına gönderebilmek için savechanges'ı aşağıdaki gibi tek seferde kullanmak hem maliyet hem de yönetilebilirlik açısından katkıda bulunmuş olacaktır.
        #endregion
        #region AddRange
        //ETicaretContext context = new ETicaretContext();
        //Urun urun1 = new Urun()
        //{
        //    UrunAdi = "I Ürünü",
        //    Fiyat = 9000
        //};
        //Urun urun2 = new Urun()
        //{
        //    UrunAdi = "İ Ürünü",
        //    Fiyat = 10000
        //};
        //Urun urun3 = new Urun()
        //{
        //    UrunAdi = "J Ürünü",
        //    Fiyat = 11000
        //};

        //await context.Urunler.AddRangeAsync(urun1, urun2, urun3);
        //await context.SaveChangesAsync();
        #endregion
        #region Eklenen Verinin Generate Edilen Id'sini Elde Etme
        ETicaretContext context = new ETicaretContext();
        Urun urun = new Urun()
        {
            UrunAdi = "X Ürünü",
            Fiyat = 999
        };

        await context.AddAsync(urun);
        await context.SaveChangesAsync();
        Console.WriteLine(urun.Id);
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