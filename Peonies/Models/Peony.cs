using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Reflection.Metadata;

namespace Peonies.Models
{
    public class Peony
    {
        public int PeonyId { get; set; }
        public string Name { get; set; }
        public PeonyType Type { get; set; }
        public Variety Variety { get; set; }
    }
}
