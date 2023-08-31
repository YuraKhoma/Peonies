using Microsoft.AspNetCore.Mvc;
using Peonies.DataBaseAccess;
using Peonies.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Peonies.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientController : Controller
    {

        private MyDbContext dbContext = new MyDbContext();

        // GET: /Clients/
        public IEnumerable<Client> Index(int? page)
        {
            //page = 1;
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var res = dbContext.Clients
                .OrderBy(x => x.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return res;

        }

        // GET: //
        public Client Detail(int id)
        {
            var data = dbContext.Clients
                .Where(x => x.ClientId == id)
                .FirstOrDefault();

            return data;
        }

        [HttpPost]
        public void Add(string name)
        {
            Client client = new Client { Name = name };
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
        }


        [HttpPut]
        public void Edit(string name, int clientId)
        {
            var client = dbContext.Clients.First(a => a.ClientId == clientId);
            client.Name = name;
            dbContext.SaveChanges();
        }

        [HttpPost]
        public void Delete(int clientId)
        {
            Client client = dbContext.Clients.Find(clientId);
            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();
        }


        [HttpGet]
        public void AddOrder(int id)
        {
            Client client = dbContext.Clients.Find(id);

            var ord = new Order()
            {
                CreatedOn = DateTime.Now,
                Number = "test",
                Client = client
            };

            dbContext.Orders.Add(ord);
            dbContext.SaveChanges();
        }
    }
}
