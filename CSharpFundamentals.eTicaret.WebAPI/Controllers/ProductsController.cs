using CSharpFundamentals.eTicaret.WebAPI.Context;
using CSharpFundamentals.eTicaret.WebAPI.DTOs;
using CSharpFundamentals.eTicaret.WebAPI.Services;
using Mapster;
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

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        ApplicationDbContext dbContext = new();
        var product = dbContext.Products
            .Where(p => p.IsDeleted == false && p.Id == id)
            .FirstOrDefault();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(ProductCreateDto request)
    {
        ProductService productService = new();
        productService.Create(request);
        var res = new { message = "Kayıt işlemi başarıyla tamamlandı" };
        return Ok(res);
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

    [HttpPut]
    public IActionResult Update(ProductUpdateDto request)
    {
        ApplicationDbContext dbContext = new();
        var product = dbContext.Products.Find(request.Id);
        if (product is null)
        {
            var res1 = new { message = "Kayıt bulunamadı" };
            return BadRequest(res1);
        }

        //product.Name = request.Name;
        //product.Price = request.Price;
        //product.Stock = request.Stock;
        request.Adapt(product);
        dbContext.Products.Update(product);
        dbContext.SaveChanges();

        var res2 = new { message = "Kayıt başarıyla güncellendi" };
        return Ok(res2);
    }
}
