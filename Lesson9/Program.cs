﻿using Microsoft.EntityFrameworkCore;

namespace Lesson9;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=ETicaretDB;Trusted_Connection=True");
        //Provider
        //ConnectionString
        //Lazy Loading
        //vb.
    }
}

public class Urun
{
    //public int Id { get; set; }
    //public int ID { get; set; }
    //public int UrunId { get; set; }
    public int UrunID { get; set; }
}

#region OnConfiguring İle Konfigürasyon Ayarlarını Gerçekleştirmek
//EF Core tool'unu yapılandırmak için kullandığımız bir metottur.
//Context nesnesinde override edilerek kullanılmaktadır.
#endregion
#region Basit Düzeyde Entity Tanımlama Kuralları
//EF Core, her tablonun varsayılan olarak bir primary key kolonu olması gerektiğini kabul eder!
//Haliyle, bu kolonu temsil eden bir property tanımlamadığımız taktirde hata verecektir.
#endregion
#region Tablo Adını Değiştirme

#endregion