namespace all_spice_dotnet.Controllers;

[ApiController]
[Route("api/{controller}")]
public class FavoritesController : ControllerBase
{
  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
  {
    _favoritesService = favoritesService;
    _auth0Provider = auth0Provider;
  }
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;
}