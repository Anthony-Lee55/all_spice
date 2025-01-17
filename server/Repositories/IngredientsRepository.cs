



namespace all_spice_dotnet.Repositories;

public class IngredientsRepository
{
  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
      INSERT INTO 
      ingredients(name, quantity, recipe_id)
      VALUES(@Name, @quantity, @RecipeId);

      SELECT
      ingredients.*
      FROM ingredients
      WHERE ingredients.id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).SingleOrDefault();
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
  {
    string sql = @"
            SELECT
      ingredients.*,
      accounts.*
      FROM ingredients
      JOIN accounts ON accounts.id = ingredients.id
      WHERE recipe_id = @recipeId";

    List<Ingredient> ingredients = _db.Query(sql, (Ingredient ingredient, Profile account) =>
    {
      ingredient.Creator = account;
      return ingredient;
    }, new { recipeId }).ToList();
    return ingredients;
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    string sql = @"
    SELECT ingredients.* FROM ingredients WHERE ingredients.id= @ingredientId;";

    Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).SingleOrDefault();

    return ingredient;
  }

  internal void DeleteIngredient(int ingredientId)
  {
    string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { ingredientId });

    if (rowsAffected == 0) throw new Exception("Delete was Successful!");
    if (rowsAffected > 1) throw new Exception("Delete was too Successful!");

  }
}