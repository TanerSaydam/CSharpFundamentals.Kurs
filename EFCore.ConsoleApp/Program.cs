using EFCore.ConsoleApp.Context;

Console.WriteLine("EF Core - LINQ Queries");

ApplicationDbContext dbContext = new();

var id = Guid.Parse("01A1256E-3DAB-77B3-B915-D194B45F15AE");

var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
if (product is null)
{
    Console.WriteLine("Product not found.");
    return;
}

product.Name = "Laptop";

dbContext.Products.Update(product);

dbContext.SaveChanges();


#region Create
//var product = new Product()
//{
//    Name = "Bilgisayar",
//    Price = 500
//};

//var dbContext = new ApplicationDbContext();

//dbContext.Products.Add(product);

//int res = dbContext.SaveChanges();
#endregion