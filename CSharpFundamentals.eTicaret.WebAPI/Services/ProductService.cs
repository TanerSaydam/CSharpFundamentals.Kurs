using CSharpFundamentals.eTicaret.WebAPI.Context;
using CSharpFundamentals.eTicaret.WebAPI.DTOs;
using CSharpFundamentals.eTicaret.WebAPI.Models;
using Mapster;

namespace CSharpFundamentals.eTicaret.WebAPI.Services;

public class ProductService
{
    public void Create(ProductCreateDto request)
    {
        ApplicationDbContext dbContext = new();

        bool isNameExists = dbContext.Products.Any(p => p.Name == request.Name);
        if (isNameExists == true)
        {
            throw new ArgumentException("Bu isimde bir ürün zaten mevcut");
        }

        //Product product = new()
        //{
        //    Name = request.Name,
        //    Price = request.Price,
        //    Stock = request.Stock
        //};
        Product product = request.Adapt<Product>();

        dbContext.Products.Add(product);
        dbContext.SaveChanges();
    }
}
