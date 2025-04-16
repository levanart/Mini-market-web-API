using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int? CategoryId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Price must be non-negative")]
    public decimal Price { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative")]
    public int? Stock { get; set; }
}