namespace EFCore.ConsoleApp;

public class Test
{
    public void Method()
    {
        //LINQ Queries / LINQ Sorguları

        #region Transaction
        //var dbContext = new ApplicationDbContext();

        //try
        //{
        //    dbContext.Database.BeginTransaction();
        //    var product = new Product()
        //    {
        //        Name = "PC",
        //        Price = 500
        //    };
        //    dbContext.Products.Add(product); //memory e kaydeder
        //    dbContext.SaveChanges();
        //    //throw new Exception();
        //}
        //catch (Exception)
        //{
        //    dbContext.Database.RollbackTransaction();
        //    return;
        //}

        //dbContext.Database.CommitTransaction();
        #endregion

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

        #region Read
        //var dbContext = new ApplicationDbContext();
        //var products = dbContext.Products.OrderBy(p => p.Name).ToList();
        //var products = dbContext.Products.Where(p => p.Name.Contains("t")).ToList(); ;
        //var products = dbContext.Products.OrderBy(p => p.Name).ThenBy(i => i.Price).ToList();
        //var products = dbContext.Products
        //    .Where(p => p.Name.Contains("t"))
        //    .Where(i => i.Price >= 100)
        //    .FirstOrDefault();

        //Console.WriteLine("Products Count: {0}", products.Count);
        #endregion

        #region Update
        //ApplicationDbContext dbContext = new();

        //var id = Guid.Parse("01A1256E-3DAB-77B3-B915-D194B45F15AE");

        //var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
        //if (product is null)
        //{
        //    Console.WriteLine("Product not found.");
        //    return;
        //}

        //product.Name = "Laptop";

        //dbContext.Products.Update(product);

        //dbContext.SaveChanges();
        #endregion

        #region Delete
        //Guid id = Guid.Parse("01a1256e-3dab-77b3-b915-d194b45f15ae");

        //var dbContext = new ApplicationDbContext();
        //Product? product = dbContext.Products.Find(id);

        //if (product is null)
        //{
        //    Console.WriteLine("Product not found.");
        //    return;
        //}

        //dbContext.Products.Remove(product);
        //dbContext.SaveChanges();
        #endregion
    }
}
