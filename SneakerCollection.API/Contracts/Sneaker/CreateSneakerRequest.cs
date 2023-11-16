namespace SneakerCollection.API.Contracts.Sneaker
{
    public record CreateSneakerRequest(
        string Name,
        string Brand,
        double Price,
        int Size,
        int Year,
        int Rate
        );
}
