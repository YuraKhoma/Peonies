using Microsoft.AspNetCore.Mvc;
using Peonies.DataBaseAccess;
using Peonies.Models;

namespace Peonies.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private MyDbContext dbContext = new MyDbContext();

        [HttpPost]
        public void Add(int amount, int fullPrice, int peonyId, int clientId)
        {
            Order order = new Order
            {
                CreatedOn = DateTime.Now,
                Quantity = amount,
                FullPrice = fullPrice,
                Peonies = new List<Peony> {dbContext.Peonies.First(a => a.PeonyId == peonyId) },
                Client = dbContext.Clients.First(a => a.ClientId == clientId)

            };


            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
    }
}
