using CSharpFundamentals.ConsoleApp;

Console.WriteLine("Ürün kaydetme ekranına hoş geldiniz");
Console.WriteLine("----------------------------");

string res = "";

while (res != "exit")
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Ürün adı girin: ");

    Console.ForegroundColor = ConsoleColor.Gray;
    var productName = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Ürün stoğunu girin: ");

    Console.ForegroundColor = ConsoleColor.Gray;
    var productStock = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Ürün fiyatını girin: ");

    Console.ForegroundColor = ConsoleColor.Gray;
    var productPrice = Console.ReadLine();

    //Convert işlemi yapıyorum
    int stock = Convert.ToInt32(productStock);
    decimal price = Convert.ToDecimal(productPrice);

    Product product = new(productName ?? "Product Test", stock, price);

    Product.WriteCount();
    Console.WriteLine("-------------------------");
    Console.WriteLine("Yeni kayıt: enter / Çık: exit");
    res = Console.ReadLine();

    Console.Clear();
}

//Product product1 = new Product();
//product1.Add("Product 1", 100, 1500.5m);

//Product product2 = new();
//product1.Add("Product 2", 200, 2500.5m);

//Console.WriteLine(Product.Products.Count + " products added.");