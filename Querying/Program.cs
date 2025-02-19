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

        int urunId = 0;
        string urunAdi = "2";

        var urunler = from urun in context.Urunler where urun.Id > urunId && urun.UrunAdi.Contains(urunAdi) select urun;

        urunId = 5;
        urunAdi = "X";

        foreach (Urun urun in urunler)
        {
            Console.WriteLine(urun.UrunAdi);
        }

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

