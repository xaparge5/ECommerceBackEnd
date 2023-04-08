namespace ECommerce.HTTPAPI.Models.CustomerAddress
{
    public class CustomerAddress : EntityBase
    {
        public Guid UserId { get; set; }
        public string AddressTitle { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
       
    }
}
