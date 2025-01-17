


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

  internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId)
  {
    List<FavoriteRecipe> favoriteRecipes = _repository.GetAccountFavoriteRecipes(userId);
    return favoriteRecipes;
  }

  public Favorite GetFavoriteById(int favoriteId)
  {
    Favorite favorite = _repository.GetFavoriteById(favoriteId);

    if (favorite == null) throw new Exception("Invalid favorite id");

    return favorite;
  }

  internal string DeleteFavorite(int favoriteId, string userId)
  {
    Favorite favorite = GetFavoriteById(favoriteId);

    if (favorite.AccountId != userId) throw new Exception("You can not un-favorite some else's recipe!");

    _repository.DeleteFavorite(favoriteId);

    return "No longer a favorite!";
  }
}