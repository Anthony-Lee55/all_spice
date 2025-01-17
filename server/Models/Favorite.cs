using System.ComponentModel.DataAnnotations;

namespace all_spice_dotnet.Models;

public class Favorite
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int RecipeId { get; set; }
  [Range(0, 255)] public int AccountId { get; set; }
}