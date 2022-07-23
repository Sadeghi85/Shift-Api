using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leopard.Repository {
	public interface IStoreBase<T> : IDisposable where T : class {
		//Task<int> SaveChangesAsync();
		//Task<int> SoftDeleteAsync(Expression<Func<T, bool>> predicate);
		Task<int> DeleteAsync(Expression<Func<T, bool>> predicate);
		Task<int> InsertAsync(T entity);
		Task<int> InsertAsync(List<T> entities);
		Task<int> UpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression);
		Task<int> UpdateAsync(T entity);
		Task<List<TResult>> GetAllAsync<TResult, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection, out int totalCount);
		Task<List<TResult>> GetAllAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection, out int totalCount);
		Task<List<TResult>> GetAllWithPagingAsync<TResult>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, string orderKeySelector, string orderDirection, int pageSize, int pageNumber, out int totalCount);
		Task<List<TResult>> GetAllWithPagingAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection, int pageSize, int pageNumber, out int totalCount);
		IQueryable<T> GetAll();
		List<Expression<Func<T, bool>>> ExpressionMaker();
		void Dispose();
		ValueTask<T?> FindByIdAsync(object id);
		string? GetUserId();
	}
}
