



namespace all_spice_dotnet.Repositories;

public class FavoritesRepository
{
  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO
    favorites(recipe_id, account_id)
    VALUES(@RecipeId, @AccountId);

      SELECT
      favorites.*, 
      recipes.*,
      accounts.*
      FROM favorites
      JOIN recipes ON recipes.id = favorites.recipe_id
      JOIN accounts ON recipes.creator_id = accounts.id
      WHERE favorites.id = LAST_INSERT_ID();";

    FavoriteRecipe favoriteProfile = _db.Query(sql, (Favorite favorite, FavoriteRecipe recipe, Profile account) =>
    {
      recipe.Id = favorite.RecipeId;
      recipe.FavoriteId = favorite.Id;
      recipe.AccountId = favorite.AccountId;
      recipe.Creator = account;

      return recipe;
    }, favoriteData).SingleOrDefault();

    return favoriteProfile;
  }

  internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId)
  {
    string sql = @"
      SELECT
      favorites.*,
      recipes.*,
      accounts.*
      FROM favorites
      JOIN recipes ON favorites.recipe_id = recipes.id
      JOIN accounts ON accounts.id = recipes.creator_id
      WHERE favorites.account_id = @userId";

    List<FavoriteRecipe> favoriteRecipes = _db.Query(sql, (Favorite favorite, FavoriteRecipe recipe, Profile account) =>
    {
      recipe.AccountId = favorite.AccountId;
      recipe.FavoriteId = favorite.Id;
      recipe.Creator = account;
      return recipe;
    }, new { userId }).ToList();

    return favoriteRecipes;
  }

  internal Favorite GetFavoriteById(int favoriteId)
  {
    string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";

    Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).SingleOrDefault();

    return favorite;
  }

  internal void DeleteFavorite(int favoriteId)
  {
    string sql = "DELETE FROM favorites WHERE id = @favoriteId;";

    int rowsAffected = _db.Execute(sql, new { favoriteId });

    if (rowsAffected == 0) throw new Exception("Delete was unsuccessful!");
    if (rowsAffected > 1) throw new Exception("Delete was too unsuccessful!");
  }
}