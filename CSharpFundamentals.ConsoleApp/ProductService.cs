namespace CSharpFundamentals.ConsoleApp;

public class ProductService
{
    public static List<Product> Products = new();
    public (string, int, decimal) StartProcess()
    {
    start_point:
        string productName = Tool.MyWriteLine("Ürün adı girin:");
    stock_point:
        string productStock = Tool.MyWriteLine("Ürün stoğunu girin:");
    price_point:
        string productPrice = Tool.MyWriteLine("Ürün fiyatını girin:");


        //Convert işlemi yapıyorum
        var isConvertSuccess = int.TryParse(productStock, out int stock);
        if (!isConvertSuccess)
        {
            Console.WriteLine("Geçersiz değer girdiniz. Tekrar denemek için enter a basın");

            Console.ReadLine();
            goto stock_point;
        }
        isConvertSuccess = int.TryParse(productPrice, out int price);
        if (!isConvertSuccess)
        {
            Console.WriteLine("Geçersiz değer girdiniz. Tekrar denemek için enter a basın");

            Console.ReadLine();
            goto price_point;
        }

        return (productName, stock, price);
    }
    public void Add(string name, int stock, decimal price)
    {
        Product product = new();
        product.Add(name, stock, price);
    }
}
