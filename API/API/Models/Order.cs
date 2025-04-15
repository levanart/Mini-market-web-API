namespace API.Models;

public class Order
{
    private int _id;
    private List<int>? _products;
    private DateTime _orderDate;
    private decimal _totalPrice;
    
    public int Id { get => _id; set => _id = value; }
    public List<int>? Products { get => _products; set => _products = value; }
    public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
    public decimal TotalPrice { get => _totalPrice; set => _totalPrice = value; }

    public Order(int id, List<int>? products, DateTime orderDate, decimal totalPrice)
    {
        Id = id;
        Products = products;
        OrderDate = orderDate;
        TotalPrice = totalPrice;
    }
}