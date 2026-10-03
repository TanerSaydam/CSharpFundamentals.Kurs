using CSharpFundamentals.ConsoleApp;

menu_start:
Console.Clear();
Console.WriteLine("Stok takip sistemine hoş geldiniz!");
Tool.CreateLine();
Console.WriteLine("1) Ürün Ekle");
Console.WriteLine("2) Ürün Listesini Göster");
Console.WriteLine("3) Çıkış Yap");

string menuRes = Console.ReadLine();
if (menuRes == "1")
{
    Console.Clear();
    while (true)
    {
        Console.WriteLine("Ürün kaydetme ekranına hoş geldiniz");
        Tool.CreateLine();

        ProductService productService = new();
        var (productName, stock, price) = productService.StartProcess();
        productService.Add(productName, stock, price);

        Tool.CreateLine();
        Console.WriteLine("Yeni kayıt: enter / Ana Menü: menu / Çık: exit");
        string res = Console.ReadLine();

        if (res == "exit")
        {
            break;
        }
        else if (res == "menu")
        {
            goto menu_start;
        }
        ;

        Console.Clear();
    }
}
else if (menuRes == "2")
{
    Console.Clear();

    Console.WriteLine($"{"#",-4} {"Ürün Adı",-20} {"Stock",-10} {"Birim Fiyatı",-15}");
    Tool.CreateLine();

    for (int i = 0; i < ProductService.Products.Count; i++)
    {
        var product = ProductService.Products[i];

        Console.WriteLine(
            $"{i + 1,-4} {product.Name,-20} {product.Stock,-10} {product.Price,-15}"
        );
    }
liste_start:
    Tool.CreateLine();
    Console.WriteLine("Ana Menü: menu / Çık: exit");
    string res = Console.ReadLine();
    if (res == "exit")
    {
        Tool.CreateLine();
        Console.WriteLine("Bizi kullandığınız için teşekkürler");
        Console.WriteLine("Sistemden çıkış yapılmıştır");
    }
    else if (res == "menu")
    {
        goto menu_start;
    }
    else
    {
        Console.WriteLine("Geçersiz değer yazdınız");
        goto liste_start;
    }
}
else if (menuRes == "3")
{
    Tool.CreateLine();
    Console.WriteLine("Bizi kullandığınız için teşekkürler");
    Console.WriteLine("Sistemden çıkış yapılmıştır");
}

