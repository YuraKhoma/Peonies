using System.Data.Entity;

namespace Peonies.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int Quantity { get; set; }
        public int FullPrice { get; set; }
        public virtual List<Peony> Peonies { get; set; }
    }
}
