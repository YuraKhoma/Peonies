
using Microsoft.AspNetCore.Mvc;
using Peonies.DataBaseAccess;
using Peonies.Models;
using System.Net;
using System.Text.Json;

namespace Peonies.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientController : ControllerBase
    {

        private MyDbContext dbContext = new MyDbContext();

        // GET: /Clients/
        public IEnumerable<Client> Index()
        {
            var res = dbContext.Clients.ToList();
            return res;       
        }


        public Client Detail(int id)
        {
            var data = dbContext.Clients.Where(x => x.ClientId == id).FirstOrDefault();
            return data;
        }
    }
}
