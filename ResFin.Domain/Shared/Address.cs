namespace ResFin.Domain.Shared;

public record Address (
    string Country,
    string StateOrProvince,
    string City,
    string Street,
    string? Alley,
    string? Number,
    string? ZipCode
    );