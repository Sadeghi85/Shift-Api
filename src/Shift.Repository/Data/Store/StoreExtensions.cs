using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Repository {
	public static class StoreExtensions {

		public static IQueryable<T> OrderByExtended<T>(this IQueryable<T> source, string orderByProperty,
						  bool desc) {
			string command = desc ? "OrderByDescending" : "OrderBy";
			var type = typeof(T);
			var property = type.GetProperty(orderByProperty);
			var parameter = Expression.Parameter(type, "p");
			var propertyAccess = Expression.MakeMemberAccess(parameter, property);
			var orderByExpression = Expression.Lambda(propertyAccess, parameter);
			var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
										  source.Expression, Expression.Quote(orderByExpression));
			return source.Provider.CreateQuery<T>(resultExpression);
		}
	}
}
