using System;
using Lab10_Kapitanov_var8.Domain.Entities;

namespace Lab10_Kapitanov_var8.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
