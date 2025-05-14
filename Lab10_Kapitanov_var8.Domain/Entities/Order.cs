// Order.cs
namespace Lab10_Kapitanov_var8.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
