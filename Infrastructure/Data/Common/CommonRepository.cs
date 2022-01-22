using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Infrastructure.Data.Common
{
    public static class CommonRepository
    {
        public static IQueryable<TEntity> SortBy<TEntity>(this IQueryable<TEntity> source, string orderByList) where TEntity : class
        {
            var queryExpr = source.Expression;
            var methodAsc = "OrderBy";
            var methodDesc = "OrderByDescending";

            var orderList = orderByList.Trim().Split(',').Select(x => x.Trim()).ToList();

            foreach (var orderItem in orderList)
            {
                var command = orderItem.ToUpper().EndsWith("DESC") ? methodDesc : methodAsc;

                var propertyName = orderItem.Split(' ')[0].Trim();


                //var type = typeof(TEntity);
                var parameter = Expression.Parameter(typeof(TEntity), "p");

                PropertyInfo property = null;
                MemberExpression propertyAccess;

                property = SearchProperty(typeof(TEntity), propertyName);

                if (property == null) continue;

                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);

                queryExpr = Expression.Call(typeof(Queryable), command, new Type[] { typeof(TEntity), property.PropertyType}, queryExpr, Expression.Quote(orderByExpression));

                methodAsc = "ThenBy";
                methodDesc = "ThenByDescending";
            }



            return source.Provider.CreateQuery<TEntity>(queryExpr);
        }

        private static PropertyInfo SearchProperty(Type type, string propertyName)
        {
            foreach (var item in type.GetProperties())
                if (item.Name.ToLower() == propertyName.ToLower())
                    return item;
            return null;
        }


    }
}
