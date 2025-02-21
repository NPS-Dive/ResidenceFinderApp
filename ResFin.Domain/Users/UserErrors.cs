namespace ResFin.Domain.Users;

public static class UserErrors
    {
    public static Error NotFound = new(
        "User.NotFound",
        "The user with the given ID is not found"
    );

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "The provided credentials for the given user not valid"
    );
    }