using EFCore.ConsoleApp.Services;

Console.WriteLine("EF Core - LINQ Queries");


ProductService productService = new();

while (true)
{
    string? str = productService.ShowMenu();

    switch (str)
    {
        case "1":
            productService.AddProduct();
            break;

        case "2":
            //UpdateProduct();
            break;

        case "3":
            productService.RemoveProduct();
            break;

        case "4":
            productService.ListProduct();
            break;
    }
}