using ECommerce.HTTPAPI.Models.User;
using ECommerce.HTTPAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly DB_Context _dbContext;

        public UserController(ILogger<UserController> logger, DB_Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost]
        public void CreateUser(User input)
        {
            try
            {

                _dbContext.Add(input);
                _dbContext.SaveChanges();    
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
