namespace ResFin.WebApi.Middleware;

public record ExceptionDetails (
    string Details,
    int Status,
    string Title,
    string Type,
     IEnumerable<object>? Errors
    );