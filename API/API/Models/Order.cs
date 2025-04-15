using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Order
{
    public int Id { get; set; }
    
    [Required] 
    public List<int> Products { get; set; } = new();
    
    public DateTime OrderDate { get; set; }
    
    public decimal TotalPrice { get; set; }
}