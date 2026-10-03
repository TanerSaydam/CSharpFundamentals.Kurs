namespace CSharpFundamentals.ConsoleApp;

public class Product
{
    public Product(string name, int stock, decimal price)
    {
        Add(name, stock, price);
    }

    public static List<Product> Products = new();
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }

    public void Add(string name, int stock, decimal price)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Stock = stock;
        Price = price;

        Products.Add(this);
    }

    public static void WriteCount()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Toplam Stok Adedi: " + Products.Count);
        //return Products.Count;
    }
}