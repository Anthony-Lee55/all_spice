

namespace all_spice_dotnet.Services;

public class FavoritesService
{
  public FavoritesService(FavoritesRepository repository)
  {
    _repository = repository;
  }
  private readonly FavoritesRepository _repository;

  internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
  {
    FavoriteRecipe favoriteRecipe = _repository.CreateFavorite(favoriteData);
    return favoriteRecipe;
  }

  // internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId)
  // {
  //   List<FavoriteRecipe> favoriteRecipes = _repository.GetAccountFavoriteRecipes(userId);
  //   return favoriteRecipes;
  // }
}