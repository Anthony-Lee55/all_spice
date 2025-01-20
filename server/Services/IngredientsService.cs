


namespace all_spice_dotnet.Services;

public class IngredientsService
{
  public IngredientsService(IngredientsRepository repository, RecipesService recipesService)
  {
    _repository = repository;
    _recipesService = recipesService;
  }
  private readonly IngredientsRepository _repository;
  private readonly RecipesService _recipesService;

  internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
  {
    Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);

    if (userId != recipe.CreatorId) throw new Exception("This is not your recipe, chef");

    ingredientData.RecipeId = recipe.Id;

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

    Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);

    if (recipe.CreatorId != userId) throw new Exception("You can not delete this recipe, CHEF!");

    _repository.DeleteIngredient(ingredientId);

    return "Ingredient was deleted!";
  }
}