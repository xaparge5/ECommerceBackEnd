using ECommerce.HTTPAPI.Models.CustomerAddress;
using ECommerce.HTTPAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.HTTPAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class AddressController : Controller
    {
        private readonly ILogger<AddressController> _logger;
        private readonly DB_Context _dbContext;

        public AddressController(ILogger<AddressController> logger, DB_Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost]

        public bool Create(CustomerAddress input)
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
        [HttpDelete]
        public bool Delete(Guid id)
        {
            try
            {
                var get = _dbContext.CustomerAddresses.Where(x=>x.Id == id).FirstOrDefault();
                _dbContext.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public bool Put(CustomerAddress input)
        {
            try
            {
                var get = _dbContext.CustomerAddresses.Where(x=>x.Id == input.Id).FirstOrDefault();
                get.City = input.City;
                get.UpdateTime = DateTime.Now;
                get.UpdaterId = input.UpdaterId;
                get.AddressTitle = input.AddressTitle;
                get.Address = input.Address;
                _dbContext.Update(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public CustomerAddress GetAddress(Guid id)
        {
            try
            {
                var get = _dbContext.CustomerAddresses.Where(x=>x.Id == id).FirstOrDefault();
                return get;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
        [HttpGet]
        [Route("/Address/GetList")]
        public List<CustomerAddress> GetListByUser(Guid userId)
        {
            try
            {
                var query = from user in _dbContext.Users
                            join adres in _dbContext.CustomerAddresses on user.Id equals adres.UserId
                            select adres;
                var list = query.ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
