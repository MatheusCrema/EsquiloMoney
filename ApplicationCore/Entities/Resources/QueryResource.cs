using System;
using System.Linq;
using System.Threading.Tasks;

namespace EsquiloMoney.API.Resources
{
    public class QueryResource
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
