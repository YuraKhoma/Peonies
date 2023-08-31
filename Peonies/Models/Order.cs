using System.Data.Entity;

namespace Peonies.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
        
        public virtual Client Client { get; set; }
    }
}
