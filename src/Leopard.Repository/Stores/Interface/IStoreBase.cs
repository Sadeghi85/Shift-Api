using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leopard.Repository {
	public interface IStoreBase<T> : IDisposable where T : class {
		Task<int> SaveChangesAsync();
		//Task<int> SoftDeleteAsync(Expression<Func<T, bool>> predicate);
		Task<int> DeleteAsync(Expression<Func<T, bool>> predicate);
		Task<int> InsertAsync(T entity);
		Task<int> InsertAsync(List<T> entities);
		Task<int> UpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression);
		Task<List<TResult>> GetAllAsync<TResult, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection = "asc");
		Task<List<TResult>> GetAllAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection = "asc");

		List<Expression<Func<T, bool>>> ExpressionMaker();
	}
}