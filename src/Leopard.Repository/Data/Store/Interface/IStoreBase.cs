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
		Task<StoreViewModel<TResult>> GetAllAsync<TResult, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, bool orderDirectionDesc = true);
		Task<StoreViewModel<TResult>> GetAllAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, bool orderDirectionDesc = true);
		Task<StoreViewModel<TResult>> GetAllWithPagingAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, bool orderDirectionDesc, int pageSize = 10, int pageNumber = 0);
		Task<StoreViewModel<TResult>> GetAllWithPagingAsync<TResult>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, string orderKeySelector, bool orderDirectionDesc = true, int pageSize = 10, int pageNumber = 0);
		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
		Task<bool> AnyAsync(List<Expression<Func<T, bool>>> predicate);
		//IQueryable<T> GetAll();
		List<Expression<Func<T, bool>>> ExpressionMaker();
		new void Dispose();
		ValueTask<T?> FindByIdAsync(object id);
		Task<T?> FindByIdAsync(Expression<Func<T, bool>> predicate);
		string? GetUserId();
	}
}
