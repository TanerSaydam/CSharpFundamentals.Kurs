using Microsoft.AspNetCore.Mvc;

namespace CSharpFundamentals.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    //[HttpGet("getall")]
    //public IActionResult GetProducts(int pageNumber, int pageSize) //query params /getall?pageNumber=1&pageSize=10
    //{
    //    var res = new List<string> { "Product 1", "Product 2", "Product 3" };

    //    return Ok(res);
    //    //return StatusCode(200,res);
    //}

    [HttpGet("getall/{pageNumber}/{pageSize}")]
    public IActionResult GetProducts(int pageNumber, int pageSize) //route params /getall/1/10
    {
        List<string> res = new();
        for (int i = 0; i < 1000000; i++)
        {
            res.Add(Guid.CreateVersion7().ToString() + Guid.CreateVersion7().ToString());
        }
        //var res = new List<string> { "Product 1", "Product 2", "Product 3" };

        return Ok(res);
        //return StatusCode(200,res);
    }

    [HttpPost("create")]
    public IActionResult GetProducts(Product product)
    {
        //listeye ekleme işlemi yapılacak
        var res = new { Message = "Ürün kaydetme işlemi başarıyla tamamlandı" };
        return Ok(res);
    }
}

//best practices: eğer ikiden fazla parametre isteyeceksen object olarak istemelisin


//metot tiplerimiz
//GET
//POST - body var
//PUT - body var
//DELETE

public class Product
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
}