using BuisnessLogic.Services;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersItemController : ControllerBase
    {

        ICustomersItemService _CustomersItemService;
            public CustomersItemController(ICustomersItemService CustomersItemService)
        {
            _CustomersItemService=CustomersItemService;
        }
        // GET: api/<CustomersItemController>
        [HttpGet("GetCategoryQuentity")]
        public async Task<int> GetCategoryQuentity(int customerId, int categoryId)
        {
            return await _CustomersItemService.GetCategoryQuentity(customerId, categoryId);
        }

        [HttpGet("GetItemsByCategoryIdForCustomerAsync")]
        public async Task<List<ItemTemp>> GetItemsByCategoryIdForCustomerAsync(int categoryId, int customerId)
        {
            return await _CustomersItemService.GetItemsByCategoryIdForCustomerAsync(categoryId, customerId);
        }

        // POST api/<CostumerController>
        [HttpPost("AddOrUpdateItemForCustomerAsync")]

        public async Task AddOrUpdateItemForCustomerAsync(int customerId, int categoryId, string itemName)
        {
            await _CustomersItemService.AddOrUpdateItemForCustomerAsync(customerId, categoryId, itemName);
        }
    }
}
