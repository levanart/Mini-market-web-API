using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Product
{
    private int _id;
    private string _name = string.Empty;
    private int? _categoryId;
    private decimal? _price;
    private int? _stock;
    
    public int Id { get => _id; set => _id = value; }
    [Required] public string Name { get => _name; set => _name = value; }
    [Required] public int? CategoryId { get => _categoryId; set => _categoryId = value; }
    [Range(0, int.MaxValue, ErrorMessage = "Price must be non-negative")] [Required] public decimal? Price { get => _price; set => _price = value; }
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative")] [Required] public int? Stock { get => _stock; set => _stock = value; }
}