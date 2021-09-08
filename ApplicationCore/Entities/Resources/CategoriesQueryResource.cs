using EsquiloMoney.API.Resources;

namespace ApplicationCore.Entities.Resources
{
    public class CategoriesQueryResource : QueryResource
    {
        public int? Hierarchy { get; set; }
    }
}

