
using Microsoft.AspNetCore.Mvc;
using Peonies.DataBaseAccess;
using Peonies.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Peonies.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientController : ControllerBase
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

        public void Add(Client client)
        {
            dbContext.Clients.Add(client);

        }
    }
}
