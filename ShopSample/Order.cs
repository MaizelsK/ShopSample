using System;

namespace ShopSample
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
