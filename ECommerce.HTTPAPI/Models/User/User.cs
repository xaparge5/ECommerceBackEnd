namespace ECommerce.HTTPAPI.Models.User
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
      
    }
}
