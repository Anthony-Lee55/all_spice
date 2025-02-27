



namespace all_spice_dotnet.Services;

public class RecipesService
{
  public RecipesService(RecipesRepository repository)
  {
    _repository = repository;
  }
  private readonly RecipesRepository _repository;

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repository.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repository.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repository.GetRecipeById(recipeId);

    if (recipe == null) throw new Exception($"Invalid recipe id: {recipeId}");

    return recipe;
  }

  internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeUpdateData)
  {
    Recipe recipe = GetRecipeById(recipeId);

    if (recipe.CreatorId != userId) throw new Exception("This isn't your recipe, CHEF!");

    recipe.Category = recipeUpdateData.Category ?? recipe.Category;
    recipe.Title = recipeUpdateData.Title ?? recipe.Title;
    recipe.Instructions = recipeUpdateData.Instructions ?? recipe.Instructions;
    recipe.Img = recipeUpdateData.Img ?? recipe.Img;

    _repository.UpdateRecipe(recipe);

    return recipe;
  }

  internal string DeleteRecipe(int recipeId, string userId)
  {
    Recipe recipe = GetRecipeById(recipeId);

    if (recipe.CreatorId != userId) throw new Exception("This isn't your recipe, CHEF!");

    _repository.DeleteRecipe(recipeId);

    return $"Deleted recipe: {recipe.Title}";
  }
}