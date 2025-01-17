using System.ComponentModel.DataAnnotations;

namespace all_spice_dotnet.Models;

public class Ingredient
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int RecipeId { get; set; }
  [MinLength(0), MaxLength(255)] public string Name { get; set; }
  [MinLength(0), MaxLength(255)] public string Quantity { get; set; }
  public Profile Creator { get; set; }
}