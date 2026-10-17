using CSharpFundamentals.eTicaret.WebAPI.Abstractions;

namespace CSharpFundamentals.eTicaret.WebAPI.Models;

public class Product : Entity
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}