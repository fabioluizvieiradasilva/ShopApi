

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.HomeController
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get ([FromServices] DataContext context)
        {
            var employee = new User {Id = 1, Username="luiz", Password = "luiz", Role="employee"};
            var manager = new User {Id = 2, Username="fabio", Password = "fabio", Role="manager"};
            var category = new Category {Id = 1, Title = "Informática"};
            var product = new Product {Id = 1, Category = category, Title="Teclado", Price=50, Description="Teclado USB Microsoft"};

            context.Users.Add(employee);
            context.Users.Add(manager);
            context.Categories.Add(category);
            context.Products.Add(product);

            await context.SaveChangesAsync();

            return Ok( new { message = "Dados configurados!"});
        }
    }
    
}