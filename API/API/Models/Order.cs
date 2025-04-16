using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Order
{
    public int Id { get; set; }
    
    [Required]
    [MinLength(1)]
    public List<int> Products { get; set; } = new();
    
    public DateTime OrderDate { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public Dictionary<int, string>? DeletedProducts { get; set; }
}