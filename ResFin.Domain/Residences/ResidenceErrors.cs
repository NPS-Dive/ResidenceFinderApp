namespace ResFin.Domain.Residences;

public static class ResidenceErrors
{
    public static Error NotFound = new(
        "Residence.NotFound",
        "The residence with the given ID is not found"
        );
}