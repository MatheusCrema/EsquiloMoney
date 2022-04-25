using AutoMapper;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Resources;
using ApplicationCore.Entities.Queries;

namespace ApplicationCore.Extensions.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile() 
        {
            //Account
            CreateMap<Account, AccountResource>();

            CreateMap<QueryResult<Account>, QueryResultResource<AccountResource>>();


            //Category
            CreateMap<Category, CategoryResource>();

            CreateMap<QueryResult<Category>, QueryResultResource<CategoryResource>>();

            //CategoryBalance
            CreateMap<CategoryBalance, CategoryBalanceResource>();

            CreateMap<QueryResult<CategoryBalance>, QueryResultResource<CategoryBalanceResource>>();


            //Identity
            CreateMap<Identity, IdentityResource>();

            CreateMap<QueryResult<Identity>, QueryResultResource<IdentityResource>>();

            //Transaction
            CreateMap<Transaction, TransactionResource>();

            CreateMap<QueryResult<Transaction>, QueryResultResource<TransactionResource>>();

        }
    }
}
