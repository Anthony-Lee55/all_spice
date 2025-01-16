
namespace all_spice_dotnet.Repositories;

public class RecipesRepository
{
  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO
    recipes(title, instructions, category, img, creator_id)
    VALUES(@Title, @Instructions, @Category, @Img, @CreatorId);
    
    SELECT 
    recipes.*,
    accounts.*  
    FROM recipes
    JOIN accounts ON recipes.creator_id = accounts.id 
    WHERE recipes.id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Profile account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, recipeData).SingleOrDefault();

    return recipe;
  }
}