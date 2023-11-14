namespace SneakerCollection.API.Contracts.Authentication
{
    public record LoginRequest
    (
        string Email,
        string Password
    );
}
