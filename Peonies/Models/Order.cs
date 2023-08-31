using System.Data.Entity;

namespace Peonies.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Quantity { get; set; }
        public int FullPrice { get; set; }
        public virtual List<Peony> Peonies { get; set; }
        public virtual Client Client { get; set; }
    }
}
