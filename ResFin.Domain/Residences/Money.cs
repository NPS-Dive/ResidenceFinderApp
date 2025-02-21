namespace ResFin.Domain.Residences;

public record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money first, Money second)
    {
        if (first.Currency != second.Currency)
        {
            throw new InvalidOperationException("Currencies shall be the same");
        }

        return new Money(first.Amount + second.Amount, first.Currency);
    }

    public static Money Zero() => new(0, Currency.None);
}