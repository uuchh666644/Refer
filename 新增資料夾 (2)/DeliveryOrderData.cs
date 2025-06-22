using System.Collections.Generic;

namespace afterservice
{
    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class DeliveryOrderData
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}