
namespace all_spice_dotnet.Services;

public class FavoritesService
{
  public FavoritesService(FavoritesRepository repository)
  {
    _repository = repository;
  }
  private readonly FavoritesRepository _repository;

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    Favorite favorite = _repository.CreateFavorite(favoriteData);
    return favorite;
  }
}