using DataAccess.DBModels;
using Microsoft.AspNetCore.Mvc;
using Shopping_List.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopping_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItemService _ItemService;
        public ItemsController(IItemService ItemService)
        {
            _ItemService = ItemService;
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _ItemService.GetAllItemsAsync();
        }


        [HttpPost]
        public async Task AddItemAsync(string itemName, string categoryName)
        {
            await _ItemService.AddItemAsync(itemName, categoryName);
        }
        // DELETE api/<ItemsController>/5
        [HttpDelete()]
        public async Task DeleteItemByIdAsync(int itemId)
        {
            await _ItemService.DeleteItemByIdAsync(itemId);
        }

    }
}
