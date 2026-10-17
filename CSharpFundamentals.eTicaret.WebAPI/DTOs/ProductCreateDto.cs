namespace CSharpFundamentals.eTicaret.WebAPI.DTOs;

public record ProductCreateDto(
    string Name,
    decimal Price,
    int Stock
);
