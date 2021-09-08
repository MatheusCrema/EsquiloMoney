using AutoMapper;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Resources;
using ApplicationCore.Entities.Queries;

namespace ApplicationCore.Extensions.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        
        public ResourceToModelProfile() 
        {
            //Account
            CreateMap<AccountsQueryResource, AccountsQuery>();
            //CreateMap<SaveAccountResource, Account>();
            //CreateMap<UpdateAccountResource, Account>();

            //Category
            CreateMap<CategoriesQueryResource, CategoriesQuery>();

            CreateMap<SaveCategoryResource, Category>();

            CreateMap<UpdateCategoryResource, Category>();

            //CategoryBalance
            CreateMap<CategoryBalancesQueryResource, CategoryBalancesQuery>();

            CreateMap<SaveCategoryBalanceResource, CategoryBalance>();
        }
    }
}
