using ECommerce.HTTPAPI.Models;
using ECommerce.HTTPAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class BasketController : Controller
    {
        private readonly ILogger<BasketController> _logger;
        private readonly DB_Context _dbContext;

        public BasketController(ILogger<BasketController> logger, DB_Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost]

        public bool AddBasket(Basket input)
        {
            try
            {
                input.CreationTime = DateTime.Now;
                _dbContext.Add(input);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public List<Product> GetBasketList(Guid userId)
        {
            try
            {
                List<Product> products1 = new List<Product>();
                var basket = _dbContext.Baskets.Where(x=>x.UserId == userId).ToList();
                var query = from baskets in basket
                            join products in  _dbContext.Products on baskets.ProductId equals products.Id
                            select new { baskets, products };

                products1 = query.Select(x=>x.products).ToList();

                return products1;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public bool DeleteBasket(Guid userId,Guid productId)
        {
            try
            {
                var get = _dbContext.Baskets.Where(x=>x.ProductId == productId && x.UserId == userId).FirstOrDefault();
                _dbContext.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
