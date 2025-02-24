using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace ChangeTracker;

internal class Program
{
    static async Task Main(string[] args)
    {
        ETicaretContext context = new();

        #region ChangeTracking Neydi?
        //Context nesnesi üzerinden gelen tüm nesneler/veriler otomatik olarak bir takip mekanizması tarafından izlenirler. İşte bu takip mekanizmasına Change Tracker denir. Change Traker ile nesneler üzerindeki değişiklikler/işlemler takip edilerek netice itibariyle bu işlemlerin fıtratına uygun sql sorgucukları generate edilir. İşte bu işleme de Change Tracking denir. 
        #endregion

        #region ChangeTracker Propertysi
        //Takip edilen nesnelere erişebilmemizi sağlayan ve gerektiği taktirde işlemler gerçekşetirmemizi sağlayan bir propertydir.
        //Context sınıfının base class'ı olan DbContext sınıfının bir member'ıdır.

        //var urunler = await context.Urunler.ToListAsync();

        //urunler[6].Fiyat = 123; //Update
        //context.Urunler.Remove(urunler[7]); //Delete
        //urunler[8].UrunAdi = "Yeni İsim"; //Update

        //var datas = context.ChangeTracker.Entries();

        //await context.SaveChangesAsync();

        #region DetectChanges Metodu
        //EF Core, context nesnesi tarafından izlenen tüm nesnelerdeki değişiklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan verisel değişiklikler yakalanarak bunların anlık görüntüleri(snapshot)'ini oluşturabilir.
        //Yapılan değişikliklerin veritabanına gönderilmeden önce algılandığından emin olmak gerekir. SaveChanges fonksiyonu çağrıldığı anda nesneler EF Core tarafından otomatik kontrol edilirler.
        //Ancak, yapılan operasyonlarda güncel tracking verilerinden emin olabilmek için değişişiklerin algıulanmasını opsiyonel olarak gerçekleştirmek isteyebiliriz. İşte bunun için DetectChanges fonksiyonu kullanılabilir ve her ne kadar EF Core değişikleri otomatik algılıyor olsa da siz yine de iradenizle kontrole zorlayabilirsiniz.

        //var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
        //urun.Fiyat = 123;

        //context.ChangeTracker.DetectChanges();
        //await context.SaveChangesAsync();
        #endregion

        #region AutoDetectChangesEnables Propertysi
        //İlgili metotlar(SaveChanges, Entries) tarafından DetectChanges metodunun otomatik olarak tetiklenmesinin konfigürasyonunu yapmamızı sağlayan proeportydir.
        //SaveChanges fonksiyonu tetiklendiğinde DetectChanges metodunu içerisinde default olarak çağırmaktadır. Bu durumda DetectChanges fonksiyonunun kullanımını irademizle yönetmek ve maliyet/performans optimizasyonu yapmak istediğimiz durumlarda AutoDetectChangesEnabled özelliğini kapatabiliriz.
        #endregion

        #region Entries Metodu
        //Context'te ki Entry metodunun koleksiyonel versiyonudur.
        //Change Tracker mekanizması tarafından izlenen her entity nesnesinin bigisini EntityEntry türünden elde etmemizi sağlar ve belirli işlemler yapabilmemize olanak tanır.
        //Entries metodu, DetectChanges metodunu tetikler. Bu durum da tıpkı SaveChanges'da olduğu gibi bir maliyettir. Buradaki maliyetten kaçınmak için AuthoDetectChangesEnabled özelliğine false değeri verilebilir.

        //var urunler = await context.Urunler.ToListAsync();

        //urunler.FirstOrDefault(u => u.Id == 15).Fiyat = 123; //Update
        //context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 061)); //Delete
        //urunler.FirstOrDefault(u => u.Id == 17).UrunAdi = "Yeni Ad"; //Update

        //context.ChangeTracker.Entries().ToList().ForEach(e =>
        //{
        //    if (e.State == EntityState.Unchanged)
        //    {
        //        //...
        //    }
        //    else if (e.State == EntityState.Deleted)
        //    {
        //        //...
        //    }
        //});
        #endregion

        #region AcceptAllChanges Metodu
        //SaveChanges() veya SaveChanges(true) tetiklendiğinde EF Core herşeyin yolunda olduğunu varsayarak track ettiği verilerin takibini keser yeni değişikliklerin takip edilmesini bekler. Böyle bir durumda beklenmeyen bir durum/olası bir hata söz konusu olursa eğer EF Core takip ettiği nesneleri brakacağı için bir düzeltme mevzu bahis olamayacaktır.

        //Haliyle bu durumda devreye SaveChanges(false) ve AcceptAllChanges metotları girecektir.

        //SaveChanges(False), EF Core'a gerekli veritabanı komutlarını yürütmesini söyler ancak gerektiğinde yeniden oynatılabilmesi için değişikleri beklemeye/nesneleri takip etmeye devam eder. Taa ki AcceptAllChanges metodunu irademizle çağırana kadar!

        //SaveChanges(false) ile işlemin başarılı olduğundan emin olursanız AcceptAllChanges metodu ile nesnelerden takibi kesebilirsiniz.

        //var urunler = await context.Urunler.ToListAsync();

        //urunler.FirstOrDefault(u => u.Id == 15).Fiyat = 123; //Update
        //context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 061)); //Delete
        //urunler.FirstOrDefault(u => u.Id == 17).UrunAdi = "Yeni Ad"; //Update

        //await context.SaveChangesAsync(false);
        //context.ChangeTracker.AcceptAllChanges();
        #endregion

        #region HasChanges Metodu
        //Takip edilen nesneler arasından değişiklik yapılanların olup olmadığının bilgisini verir.
        //Arkaplanda DetectChanges metodunu tetikler.
        //var result = context.ChangeTracker.HasChanges();
        #endregion
        #endregion

        #region Entity States
        #region Detached

        #endregion

        #region Added

        #endregion

        #region Unchanged

        #endregion

        #region Modified

        #endregion

        #region Deleted

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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {

            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
}
