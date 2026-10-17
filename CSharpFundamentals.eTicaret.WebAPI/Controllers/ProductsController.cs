using CSharpFundamentals.eTicaret.WebAPI.Context;
using CSharpFundamentals.eTicaret.WebAPI.DTOs;
using CSharpFundamentals.eTicaret.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpFundamentals.eTicaret.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        ApplicationDbContext dbContext = new();
        var products = dbContext.Products
            .Where(p => p.IsDeleted == false)
            .OrderBy(x => x.Name)
            .ToList();

        return Ok(products);
    }

    [HttpPost]
    public IActionResult Create(ProductCreateDto request)
    {
        ApplicationDbContext dbContext = new();

        bool isNameExists = dbContext.Products.Any(p => p.Name == request.Name);
        if (isNameExists == true)
        {
            var res1 = new { message = "Bu isimde bir ürün zaten mevcut" };
            return BadRequest(res1);
        }

        Product product = new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };

        dbContext.Products.Add(product);
        dbContext.SaveChanges();
        var res2 = new { message = "Kayıt işlemi başarıyla tamamlandı" };
        return Ok(res2);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        ApplicationDbContext dbContext = new();
        var product = dbContext.Products.Find(id);
        if (product is null)
        {
            var res1 = new { message = "Kayıt bulunamadı" };
            return BadRequest(res1);
        }

        product.IsDeleted = true;
        dbContext.Products.Update(product);
        dbContext.SaveChanges();

        var res2 = new { message = "Kayıt başarıyla silindi" };
        return Ok(res2);
    }
}
