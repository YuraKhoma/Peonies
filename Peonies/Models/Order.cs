using System.Data.Entity;

namespace Peonies.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
