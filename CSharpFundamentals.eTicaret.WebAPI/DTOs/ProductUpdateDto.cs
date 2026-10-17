namespace CSharpFundamentals.eTicaret.WebAPI.DTOs;

public record ProductUpdateDto(
    Guid Id,
    string Name,
    decimal Price,
    int Stock
);
