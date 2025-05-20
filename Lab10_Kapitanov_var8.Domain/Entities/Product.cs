using System.Text.Json.Serialization;

namespace Lab10_Kapitanov_var8.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
