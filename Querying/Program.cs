using Microsoft.EntityFrameworkCore;

namespace Querying;

internal class Program
{
    static async Task Main(string[] args)
    {
        ETicaretContext context = new ETicaretContext();

        #region En Temel Basit Bir Sorgulama Nasıl Yapılır?
        #region Method Syntax
        //var urunler = await context.Urunler.ToListAsync();
        #endregion
        #region Query Syntax
        //var urunler2 = await (from urun in context.Urunler select urun).ToListAsync();
        #endregion
        #endregion

        #region Sorguyu Execute Etmek İçin Ne Yapmamız Gerekmektedir?
        #region ToListAsync
        #region Method Syntax
        //var urunler = await context.Urunler.ToListAsync();
        #endregion
        #region Query Syntax
        //var urunler = await (from urun in context.Urunler select urun).ToListAsync();
        #endregion
        #endregion

        //int urunId = 0;
        //string urunAdi = "2";

        //var urunler = from urun in context.Urunler where urun.Id > urunId && urun.UrunAdi.Contains(urunAdi) select urun;

        //urunId = 5;
        //urunAdi = "X";

        //foreach (Urun urun in urunler)
        //{
        //    Console.WriteLine(urun.UrunAdi);
        //}

        //urunler.ToListAsync();

        #region Foreach

        //foreach (var urun in urunler)
        //{
        //    Console.WriteLine(urun.UrunAdi);
        //}

        #region Deferred Execution (Ertelenmiş Çalışma)
        //IQueryable çalışmalarında ilgili kod yazıldığı noktada tetiklenmez/çalıştırılmaz yani ilgili kod yazıldığı noktada sorguyu generate etmez! Nerede eder? Çalıştırıldığı/execute edildiği noktada tetiklenir! İşte bu duruma da ertelenmiş çalışma denir!
        #endregion
        #endregion
        #endregion

        #region IQueryable ve IEnumerable Nedir? Basit Olarak!
        #region IQueryable
        //Sorguya karşılık gelir.
        //EF Core üzerinden yapılmış olan sorgunun execute edilmemiş halini ifade eder.
        #endregion
        #region IEnumerable
        //Sorgunun çalıştırılıp/execute edilip verilerin in memory'ye yüklenmiş halini ifade eder.
        #endregion
        //var urunler = from urun in context.Urunler select urun;
        //var urunler = await (from urun in context.Urunler select urun).ToListAsync();
        #endregion

        #region Çoğul Veri Getiren Sorgulama Fonksiyonları
        #region ToListAsync
        //Üretilen sorguyu execute ettirmemizi sağlayan bir fonksiyondur.
        //var urunler = await context.Urunler.ToListAsync();
        //var urunler = await (from urun in context.Urunler select urun).ToListAsync();

        //var urunler = from urun in context.Urunler select urun;
        //var datas = await urunler.ToListAsync();
        #endregion

        #region Where
        //Oluşturulan soruya where şartı eklememizi sağlayan bir fonksiyondur.
        //var urunler = await context.Urunler.Where(u => u.Id > 500).ToListAsync();
        //var urunler = await context.Urunler.Where(u => u.UrunAdi.StartsWith("a")).ToListAsync();

        //var urunler = from urun in context.Urunler where urun.Id > 500 && urun.UrunAdi.EndsWith("7") select urun;
        //var data = await urunler.ToListAsync();
        #endregion

        #region OrderBy
        //Sorgu üzerinde sıralama yapmamızı sağlayan bir fonksiyondur.
        //var urunler = context.Urunler.Where(u => u.Id > 3 || u.UrunAdi.EndsWith("ü")).OrderBy(u => u.UrunAdi);
        //var data = await urunler.ToListAsync();

        //var urunler = from urun in context.Urunler where urun.Id > 3 || urun.UrunAdi.EndsWith("ü") orderby urun.UrunAdi select urun;
        //var urunler = from urun in context.Urunler where urun.Id > 3 || urun.UrunAdi.EndsWith("ü") orderby urun.UrunAdi ascending select urun;
        //var data = await urunler.ToListAsync();

        #region ThenBy
        //OrderBy üzerinde yapılan sıralama işlemini farklı kolonlara da uygulamamızı sağlayan bir fonksiyondur. (Ascending)
        //var urunler = context.Urunler.Where(u => u.Id > 3 || u.UrunAdi.EndsWith("ü")).OrderBy(u => u.UrunAdi).ThenBy(u => u.Fiyat).ThenBy(u => u.Id);
        //var data = await urunler.ToListAsync();
        #endregion
        #endregion

        #region OrderByDescending
        //Descending olarak sıralama yapmamızı sağlar.
        //ThenByDescending de mevcuttur.
        #endregion
        #endregion

        #region Tekil Veri Getiren Sorgulama Fonksiyonları
        //Yapılan sorguda sadece ve sadece tek bir verinin gelmesi amaçlanıyorsa Single ya da SingleOrDefault fonksiyonları kullanılabilir.
        #region SingleAsync
        //Eğer sorgu neticesinde birden fazla veri geliyorsa ya da hiç gelmiyorsa her iki durumda da exception fırlatır.
        #region Tek Kayıt Geldiğinde
        //var urun = await context.Urunler.SingleAsync(u => u.Id == 15);
        #endregion
        #region Hiç Kayıt Gelmediğinde
        //var urun = await context.Urunler.SingleAsync(u => u.Id == 1515);
        #endregion
        #region Birden Çok Kayıt Geldiğinde
        //var urun = await context.Urunler.SingleAsync(u => u.Id > 15);
        #endregion
        #endregion

        #region SingleOrDefaultAsync
        //Eğer sorgu neticesinde birden fazla veri geliyorsa exception fırlatır, hiç veri gelmiyorsa null döner.
        #region Tek Kayıt Geldiğinde
        //var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 15);
        #endregion
        #region Hiç Kayıt Gelmediğinde
        //var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 1515);
        #endregion
        #region Birden Çok Kayıt Geldiğinde
        //var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id > 15);
        #endregion
        #endregion

        //Yapılan sorguda tek bir verinin gelmesi amaçlanıyorsa First ya da FirstOrDefault fonksiyonları kullanılabilir.
        #region FirstAsync
        //Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa hata fırlatır.
        #region Tek Kayıt Geldiğinde
        //var urun = await context.Urunler.FirstAsync(u => u.Id == 15);
        #endregion
        #region Hiç Kayıt Gelmediğinde
        //var urun = await context.Urunler.FirstAsync(u => u.Id == 1515);
        #endregion
        #region Birden Çok Kayıt Geldiğinde
        //var urun = await context.Urunler.FirstAsync(u => u.Id > 15);
        #endregion
        #endregion

        #region FirstOrDefaultAsync
        //Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa null döner.
        #region Tek Kayıt Geldiğinde
        //var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 15);
        #endregion
        #region Hiç Kayıt Gelmediğinde
        //var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 1515);
        #endregion
        #region Birden Çok Kayıt Geldiğinde
        //var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id > 15);
        #endregion
        #endregion

        #region FindAsync
        //Find fonksiyonu, primary key kolonuna özel hızlı bir şekilde sorgulama yapmamızı sağlayan bir fonksiyondur. 

        //Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 15);
        //Urun urun = await context.Urunler.FindAsync(15);
        #region Composite Primary key Durumu
        //https://github.com/gncyyldz/EF-Core-Training/blob/master/Querying/Program.cs satır 213 incele. Context ve Entity'leri de incele.
        #endregion
        #endregion

        #region LastAsync
        //Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelmiyorsa hata fırlatır. OrderBy kullanılması mecburidir.
        //var urun = await context.Urunler.OrderBy(u => u.Fiyat).LastAsync(u => u.Id > 55);
        #endregion

        #region LastOrDefaultAsync
        //Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelmiyorsa null döner. OrderBy kullanılması mecburidir.
        //var urun = await context.Urunler.OrderBy(u => u.Fiyat).LastOrDefaultAsync(u => u.Id > 55);
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