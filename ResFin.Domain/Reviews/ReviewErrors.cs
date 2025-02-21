namespace ResFin.Domain.Reviews;

public static class ReviewErrors
{
    public static readonly Error NotEligible = new(
        "Review.NotEligible",
        "The review is not eligible, as the given reservation is not completed yet!"
        );
    }