namespace CSharpFundamentals.ConsoleApp;

public class Product
{
    public Product()
    {

    }
    public Product(string name, int stock, decimal price)
    {
        Add(name, stock, price);
    }

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

        ProductService.Products.Add(this);
    }
}