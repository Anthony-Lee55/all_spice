namespace all_spice_dotnet.Services;

public class IngredientsService
{
  public IngredientsService(IngredientsRepository repository)
  {
    _repository = repository;
  }
  private readonly IngredientsRepository _repository;
}