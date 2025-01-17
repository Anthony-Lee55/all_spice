
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
}