using BuisnessLogic.Services;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService=CategoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _CategoryService.GetAllCategoriesAsync();
        }

        [HttpPost]
        public async Task AddCategoryAsync(string CategoryName)
        {
            await _CategoryService.AddCategoryAsync(CategoryName);
        }

        ////GET api/<CategoryController>/5
        ////[HttpGet("{id}")]
        ////public string Get(int id)
        ////{
        ////    return "value";
        ////}



        ////PUT api/<CategoryController>/5
        ////[HttpPut("{id}")]
        ////public void Put(int id, [FromBody] string value)
        ////{
        ////}

        ////DELETE api/<CategoryController>/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        ////{
        ////}
    }
}
