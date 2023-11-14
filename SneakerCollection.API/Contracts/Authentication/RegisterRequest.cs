namespace SneakerCollection.API.Contracts.Authentication
{
    public record RegisterRequest
    (
        string Email,
        string Password
    );
}
