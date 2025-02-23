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

        #region Diğer Sorgulama Fonksiyonları
        #region CountAsync
        //Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(int) bizlere bildiren fonksiyondur.
        //var urunler = (await context.Urunler.ToListAsync()).Count();
        //var urunler = await context.Urunler.CountAsync();
        #endregion

        #region LongCountAsync
        //Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(long) bizlere bildiren fonksiyondur.
        //var urunler = await context.Urunler.LongCountAsync();
        //var urunler = await context.Urunler.LongCountAsync(u => u.Fiyat > 5000);
        #endregion

        #region AnyAsync
        //Sorgu neticesinde verinin gelip gelmediğini boolean türünde dönen fonksiyondur.
        //var urunler = await context.Urunler.AnyAsync();

        //var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("1")).AnyAsync();
        //var urunler = await context.Urunler.AnyAsync(u => u.UrunAdi.Contains("1"));
        #endregion

        #region MaxAsync
        //Verilen kolondaki max değeri getirir.
        //var fiyat = await context.Urunler.MaxAsync(u => u.Fiyat);
        #endregion

        #region MinAsync
        //Verilen kolondaki min değeri getirir.
        //var fiyat = await context.Urunler.MinAsync(u => u.Fiyat);
        #endregion

        #region Distinct
        //Sorguda mükerrer kayıtlar varsa bunları tekilleştiren bir işleve sahip fonksiyondur.
        //var urunler = await context.Urunler.Distinct().ToListAsync();
        #endregion

        #region AllAsync
        //Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false döndürecektir.
        //var check = await context.Urunler.AllAsync(u => u.Fiyat > 5000);
        #endregion

        #region SumAsync
        //Vermiş olduğumuz sayısal proeprtynin toplamını alır.
        //float fiyatToplam = await context.Urunler.SumAsync(u => u.Fiyat);
        #endregion

        #region AverageAsync
        //Vermiş olduğumuz sayısal proeprtynin aritmetik ortalamasını alır.
        //var aritmetikOrtalama = await context.Urunler.AverageAsync(u => u.Fiyat);
        #endregion

        #region Contains
        //Like '%...%' sorgusu oluşturmamızı sağlar.
        //var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("7")).ToListAsync();
        #endregion

        #region StartsWith
        //Like '...%' sorgusu oluşturmamızı sağlar.
        //var urunler = await context.Urunler.Where(u => u.UrunAdi.StartsWith("7")).ToListAsync();
        #endregion

        #region EndsWith
        //Like '%...' sorgusu oluşturmamızı sağlar.
        //var urunler = await context.Urunler.Where(u => u.UrunAdi.EndsWith("7")).ToListAsync();
        #endregion
        #endregion

        #region Sorgu Sonucu Dönüşüm Fonksiyonları
        //Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultusunda farklı türlerde projecsiyon edebiliyoruz
        #region ToDictionaryAsync
        //Sorgu neticesinde gelecek olan veriyi bir dictionary olarak elde etmek/tutmak/karşılamak istiyorsak eğer kullanılır.
        //var urunler = await context.Urunler.ToDictionaryAsync(u => u.UrunAdi, u => u.Fiyat);

        //ToList ile aynı amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırlar.
        //ToList: Gelen sorgu neticesini entity türünde bir koleksiyona(List<TEntity>) dönüştürmekteyken,
        //ToDictionary: Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
        #endregion

        #region ToArrayAsync
        //Oluşturulan sorguyu dizi olarak elde eder.
        //ToList ile muadil amaca hizmet eder. Yani sorguyu execute eder lakin gelen sonucu entity dizisi olarak elde eder.
        //var urunler = await context.Urunler.ToArrayAsync();
        #endregion

        #region Select
        //var urunler = await context.Urunler.ToListAsync();

        //Select fonksiyonunun işlevsel olarak birden fazla davranışı söz konusudur,
        //1. Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır. 

        //var urunler = await context.Urunler.Select(u => new Urun
        //{
        //    Id = u.Id,
        //    Fiyat = u.Fiyat
        //}).ToListAsync();

        //2. Select fonksiyonu, gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim

        //var urunler = await context.Urunler.Select(u => new
        //{
        //    Id = u.Id,
        //    Fiyat = u.Fiyat
        //}).ToListAsync();
        #endregion

        #region SelectMany
        //Select ile aynı amaca hizmet eder. Lakin, ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar.

        //var urunler = await context.Urunler.Include(u => u.Parcalar).SelectMany(u => u.Parcalar, (u, p) => new
        //{
        //    u.Id,
        //    u.Fiyat,
        //    p.ParcaAdi
        //}).ToListAsync();
        #endregion
        #endregion

        Console.WriteLine();
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