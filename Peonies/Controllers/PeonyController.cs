using Microsoft.AspNetCore.Mvc;
using Peonies.DataBaseAccess;
using Peonies.Models;

namespace Peonies.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PeonyController
    {
        private MyDbContext dbContext = new MyDbContext();

        // GET: /Peonies/
        public IEnumerable<Peony> Index()
        {
            var res = dbContext.Peonies.ToList();
            return res;
        }


        public Peony Detail(int id)
        {
            var data = dbContext.Peonies.Where(x => x.PeonyId == id).FirstOrDefault();
            return data;
        }
    }
}
