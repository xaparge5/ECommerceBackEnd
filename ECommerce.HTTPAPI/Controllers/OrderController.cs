using ECommerce.HTTPAPI.Migrations;
using ECommerce.HTTPAPI.Models;
using ECommerce.HTTPAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly DB_Context _dbContext;

        public OrderController(ILogger<OrderController> logger, DB_Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost]

        public bool CreateOrder(Guid userId)
        {
            try
            {
                var getBaskets = _dbContext.Baskets.Where(x=>x.UserId == userId).ToList();
                foreach(var item in getBaskets)
                {
                    var product = _dbContext.Products.Where(x=>x.Id == item.ProductId).FirstOrDefault();
                    Order order = new Order();
                    order.CreationTime = DateTime.Now;
                    order.CreatorId = userId;
                    order.ProductId = item.ProductId;
                    order.Price = product.Price;
                    order.Quantity = Convert.ToInt32(item.Quantity);
                    _dbContext.Add(order);
                    _dbContext.Remove(item);
                    _dbContext.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public List<Product> GetOrderList(Guid userId)
        {
            try
            {
                var query = from order in _dbContext.Orders
                            join product in _dbContext.Products on order.ProductId equals product.Id
                            where order.CreatorId == userId
                            select product;
                var list = query.ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public bool DeleteOrder(Guid ProductId,Guid UserId)
        {
            try 
            {
                var order = _dbContext.Orders.Where(x=>x.ProductId == ProductId && x.CreatorId == UserId).FirstOrDefault();
                _dbContext.Remove(order);
                _dbContext.SaveChanges();
                return true;
            }
            catch( Exception ex ) {
                throw new Exception(ex.Message);
            }
        }
    }
}
