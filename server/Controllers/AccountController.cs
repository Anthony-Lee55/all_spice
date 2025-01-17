namespace all_spice_dotnet.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService favoritesService)
  {
    _accountService = accountService;
    _favoritesService = favoritesService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("favorites")]
  public async Task<ActionResult<List<FavoriteRecipe>>> GetAccountFavoriteRecipes()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavoriteRecipe> favoriteRecipes = _favoritesService.GetAccountFavoriteRecipes(userInfo.Id);
      return Ok(favoriteRecipes);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
