
using System.ComponentModel.DataAnnotations;

namespace all_spice_dotnet.Models;

public class Recipe
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string CreatorId { get; set; }
  [MinLength(0), MaxLength(255)] public string Title { get; set; }
  [MinLength(0), MaxLength(5000)] public string? Instructions { get; set; }
  [Url, MaxLength(2000)] public string Img { get; set; }
  public string Category { get; set; }
}