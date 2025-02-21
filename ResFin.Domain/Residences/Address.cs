using System.IO;

namespace ResFin.Domain.Residences;

public record Address (
    string Country,
    string StateOrProvince,
    string City,
    string Street,
    string? Alley,
    string? Number,
    string? ZipCode
    );