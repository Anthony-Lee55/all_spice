
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
    
    SELECT *  FROM recipes WHERE id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query<Recipe>(sql, recipeData).SingleOrDefault();

    return recipe;
  }
}