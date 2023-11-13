using BuisnessLogic.Services;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService=CustomerService;
        }
        // GET: api/<CostumerController>
        [HttpGet]
        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _CustomerService.GetAllCustomerAsync();
        }
    }
}
