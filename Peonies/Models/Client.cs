using System.Data.Entity;

namespace Peonies.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public virtual List <Order> Orders { get; set; }
    }
}
