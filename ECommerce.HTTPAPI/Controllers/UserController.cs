using ECommerce.HTTPAPI.Models.User;
using ECommerce.HTTPAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce.HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
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

        public bool CreateUser(User input)
        {
            try
            {

                _dbContext.Add(input);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]

        public JsonResult Login(string userName,string password)
        {
            try
            {
                var userCount = _dbContext.Users.Where(x=>x.UserName == userName && x.Password == password).FirstOrDefault();
                if (userCount != null)
                {
                     HttpContext.Session.SetString("SessionId", userCount.Id.ToString());
                    return Json(userCount.Id.ToString());
                }
                    
                else
                    return Json("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]

        public bool LogOut(string userName, string password)
        {
            try
            {
                var userCount = _dbContext.Users.Where(x=>x.UserName == userName && x.Password == password).FirstOrDefault();
                if (userCount != null)
                {
                    HttpContext.Session.SetString("SessionId", "");
                    return true;
                }

                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
