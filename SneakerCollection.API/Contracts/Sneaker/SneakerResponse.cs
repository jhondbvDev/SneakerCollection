namespace SneakerCollection.API.Contracts.Sneaker
{
    public record SneakerResponse(
        string Id,
        string Name,
        string Brand,
        double Price,
        int Size,
        int Year,
        int Rate

        );
}
