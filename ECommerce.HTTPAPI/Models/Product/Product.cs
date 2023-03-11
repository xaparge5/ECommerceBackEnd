namespace ECommerce.HTTPAPI.Models.Product
{
    public class Product : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get;set; }
        public string ImageUrl { get; set; }

    }
}
