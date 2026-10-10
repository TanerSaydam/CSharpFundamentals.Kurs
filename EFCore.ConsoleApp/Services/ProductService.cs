using EFCore.ConsoleApp.Context;
using EFCore.ConsoleApp.Models;

namespace EFCore.ConsoleApp.Services;

public class ProductService
{
    ApplicationDbContext dbContext = new();
    public void RemoveProduct()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Ürün Silme Sayfası");
    validation_start:
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Silinecek Ürünün Id'sini girin");
        Console.WriteLine("Ürün Id:");

        Console.ForegroundColor = ConsoleColor.Yellow;
        string? idStr = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("-------------------------------");
        if (!Guid.TryParse(idStr, out Guid id))
        {
            Console.WriteLine("Geçerli bir ID değeri girin!");
            goto validation_start;
        }

        Product? product = dbContext.Products.Find(id);
        if (product is null)
        {
            Console.WriteLine("Girdiğiniz ID'ye ait kayıt bulunamadı");
            Console.WriteLine("Geçerli bir ID girin");
            goto validation_start;
        }

        dbContext.Remove(product);
        dbContext.SaveChanges();
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Ürün başarıyla silindi");
        Console.WriteLine("Menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
        ShowMenu();
    }

    public void ListProduct()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Ürün Listesi");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"{"#",-5} {"Ürün Adı",-30} {"Birim Fiyatı",15}");
        var products = dbContext.Products.ToList();
        int index = 0;
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (var product in products)
        {
            index++;
            Console.WriteLine($"{index,-5} {product.Name,-30} {product.Price,15:N2}");
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
        ShowMenu();
    }

    public void AddProduct()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Ürün Ekleme Sayfası");
        Console.WriteLine("Ürün eklemek için aşağıdaki bilgileri doldurun!");
    validation_start:
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Ürün Adı:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Ürün adı boş olamaz!");
            goto validation_start;
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Ürün Fiyatı:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string? priceStr = Console.ReadLine();
        if (!decimal.TryParse(priceStr, out decimal price))
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Ürün fiyatı geçersiz!");
            goto validation_start;
        }

        var product = new Product()
        {
            Name = name,
            Price = price
        };
        dbContext.Add(product);
        dbContext.SaveChanges();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Ürün başarıyla eklendi!");
        Console.WriteLine("Menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
        ShowMenu();
    }

    public string? ShowMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Boss eTicaret'e Hoşgeldiniz!");
        Console.WriteLine("Size nasıl yardımcı olabilirim?");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("1. Ürün Ekle");
        Console.WriteLine("2. Ürün Güncelle");
        Console.WriteLine("3. Ürün Sil");
        Console.WriteLine("4. Ürünleri Listele");
        Console.WriteLine("-------------------------------");
        Console.ForegroundColor = ConsoleColor.Yellow;
        return Console.ReadLine();
    }
}
