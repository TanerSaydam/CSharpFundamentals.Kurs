using EFCore.ConsoleApp.Context;
using EFCore.ConsoleApp.Models;

Console.WriteLine("EF Core - LINQ Queries");


ApplicationDbContext dbContext = new();

while (true)
{
    string? str = ShowMenu();
    switch (str)
    {
        case "1":
            AddProduct();
            break;

        case "2":
            //UpdateProduct();
            break;

        case "3":
            //RemoveProduct();
            break;

        case "4":
            //ListProduct();
            break;
    }
}

void AddProduct()
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

string? ShowMenu()
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