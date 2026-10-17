using Microsoft.AspNetCore.Mvc;

namespace CSharpFundamentals.WebAPI.Controllers;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetProducts()
    {
        var res = new List<string> { "Product 1", "Product 2", "Product 3" };

        return Ok(res);
        //return StatusCode(200,res);
    }
}