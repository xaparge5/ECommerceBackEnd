namespace ECommerce.HTTPAPI.Models
{
    public class Order : EntityBase
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }   
        public decimal Price { get; set; }
       
    }
}
