namespace GameStore.Dtos;

public record class UpdatedGamesDto{
    public string Name { get; init; } = string.Empty;
    public string Genre { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public DateOnly ReleaseDate { get; init; }  // ✅ Nullable
}
