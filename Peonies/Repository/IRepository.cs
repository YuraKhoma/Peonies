using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peonies.Repository
{
    public interface IRepository
    {
        List<object> Get();
        string Add(object Model);
        string Update(object Model);
        string Delete(object Model);
    }
}
