using ECommerce.HTTPAPI.Models.Product;
using ECommerce.HTTPAPI.Models.User;
using ECommerce.HTTPAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class ProductController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly DB_Context _dbContext;

        public ProductController(ILogger<UserController> logger, DB_Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost]

        public bool CreateProduct(Product input)
        {
            try
            {

                _dbContext.Add(input);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public bool EditProduct(Product input)
        {
            try
            {
                var get = _dbContext.Products.Where(x=>x.Id == input.Id).FirstOrDefault();
                get.ImageUrl = input.ImageUrl;
                get.Price = input.Price;
                get.Description = input.Description;
                get.Title = input.Title;
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public bool DeleteProduct(Guid id)
        {
            try
            {
                var get = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
                _dbContext.Remove(get);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]

        public JsonResult GetProduct(Guid id)
        {
            try
            {

                var get = _dbContext.Products.Where(x=>x.Id == id).FirstOrDefault();
                return Json(get);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("/product/GetList")]
        public JsonResult GetList()
        {
            try
            {
                var list = _dbContext.Products.ToList();
                return Json(list);
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
