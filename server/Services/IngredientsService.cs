


namespace all_spice_dotnet.Services;

public class IngredientsService
{
  public IngredientsService(IngredientsRepository repository)
  {
    _repository = repository;
  }
  private readonly IngredientsRepository _repository;

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _repository.CreateIngredient(ingredientData);
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
  {
    List<Ingredient> ingredients = _repository.GetIngredientsForRecipe(recipeId);
    return ingredients;
  }

  private Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _repository.GetIngredientById(ingredientId);

    if (ingredient == null) throw new Exception($"Invalid ingredient id: {ingredientId}");

    return ingredient;
  }

  internal string DeleteIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);

    if (ingredient.Creator.Id != userId) throw new Exception("You can not delete this recipe, CHEF!");

    _repository.DeleteIngredient(ingredientId);

    return "Ingredient was deleted!";
  }
}