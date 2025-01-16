namespace all_spice_dotnet.Controllers;

[ApiController]
[Route("api/{controller}")]
public class RecipesController : ControllerBase
{
  public RecipesController(RecipesService recipesService)
  {
    _recipesService = recipesService;
  }
  private readonly RecipesService _recipesService;
}