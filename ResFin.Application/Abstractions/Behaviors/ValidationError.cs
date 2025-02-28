namespace ResFin.Application.Abstractions.Behaviors;

public sealed record ValidationError(
    string ValidationFailurePropertyName, 
    string ValidationFailureErrorMessage);