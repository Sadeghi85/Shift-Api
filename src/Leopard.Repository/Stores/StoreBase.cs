using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Serilog;

namespace Leopard.Repository {
	public class StoreBase<T> : IStoreBase<T> where T : class, new() {
		protected ILeopardDbContext _ctx;
		protected DbSet<T> TEntity;

		private readonly ILogger _logger;

		protected StoreBase(ILeopardDbContext ctx, ILogger logger) {
			_ctx = ctx;
			TEntity = _ctx.Instance.Set<T>();

			_logger = logger;
		}

		public Task<int> SaveChangesAsync() {
			var res = Task.FromResult(-1);
			try {
				res = _ctx.Instance.SaveChangesAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'SaveChangesAsync'");
			}
			return res;
		}
		//public virtual Task<int> SoftDeleteAsync(Expression<Func<T, bool>> predicate) {
		//	var res = Task.FromResult(-1);
		//	try {
		//		var queryresult = TEntity.Where(predicate);
		//		res = queryresult.BatchUpdateAsync(a => new T { IsDeleted = true, DeletedDateTime = DateTime.Now });
		//	} catch (Exception ex) {
		//		_logger.Error(ex, "db error, method: 'SoftDeleteAsync'");
		//	}
		//	return res;
		//}
		public virtual Task<int> DeleteAsync(Expression<Func<T, bool>> predicate) {
			var res = Task.FromResult(-1);
			try {
				var queryresult = TEntity.Where(predicate);

				res = queryresult.BatchDeleteAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'DeleteAsync'");
			}
			return res;
		}
		public virtual Task<int> InsertAsync(T entity) {
			var res = Task.FromResult(-1);
			try {
				//entity.CreateDateTime = DateTime.Now;
				var theType = entity.GetType();
				var CreateDateTimeProp = theType.GetProperty("CreateDateTime");
				if (CreateDateTimeProp != null) {
					CreateDateTimeProp.SetValue(entity, DateTime.Now);
				}

				TEntity.Add(entity);

				res = _ctx.Instance.SaveChangesAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'InsertAsync'");
			}
			return res;
		}
		public virtual Task<int> InsertAsync(List<T> entities) {
			var res = Task.FromResult(-1);
			try {
				List<T> newEntities = new List<T>();
				var now = DateTime.Now;
				foreach (var entity in entities) {
					var theType = entity.GetType();
					var CreateDateTimeProp = theType.GetProperty("CreateDateTime");
					if (CreateDateTimeProp != null) {
						CreateDateTimeProp.SetValue(entity, DateTime.Now);
					}
					newEntities.Add(entity);
				}
				//res = _ctx.Instance.BulkInsert(newEntities);

				res = Task.Run(() => {
					try {
						_ctx.Instance.BulkInsert(newEntities);
						return newEntities.Count;
					} catch (Exception ex) {
						_logger.Error(ex, "db error, method: 'InsertAsync'");

						return 0;
					}

				});
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'InsertAsync'");
			}
			return res;
		}
		public virtual Task<int> UpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression) {
			var res = Task.FromResult(-1);
			try {
				var queryresult = TEntity.Where(predicate);

				res = queryresult.BatchUpdateAsync(updateExpression);
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'UpdateAsync'");
			}
			return res;
		}
		public virtual Task<List<TResult>> GetAllAsync<TResult, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection = "asc") {
			var res = Task.FromResult(new List<TResult>());
			try {
				var queryresult = TEntity.Where(predicate);

				if (orderDirection == "asc") {
					queryresult = queryresult.OrderBy(orderKeySelector);
				} else {
					queryresult = queryresult.OrderByDescending(orderKeySelector);
				}

				res = queryresult.Select(selectList).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllAsync'");
			}
			return res;
		}
		public virtual Task<List<TResult>> GetAllAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection = "asc") {
			var res = Task.FromResult(new List<TResult>());
			try {
				if (predicate.Count <= 0) {
					return null;
				}
				var queryresult = TEntity.Where(predicate[0]);
				for (int i = 1; i < predicate.Count; i++) {
					queryresult = queryresult.Where(predicate[i]);
				}

				if (orderDirection == "asc") {
					queryresult = queryresult.OrderBy(orderKeySelector);
				} else {
					queryresult = queryresult.OrderByDescending(orderKeySelector);
				}

				res = queryresult.Select(selectList).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllAsync'");
			}
			return res;
		}

		public IQueryable<T> GetAll() {

			IQueryable<T> query = TEntity;
			return query;
		}

		public List<Expression<Func<T, bool>>> ExpressionMaker() {
			return new List<Expression<Func<T, bool>>>();
		}
		public void Dispose() {
			_ctx.Instance.Dispose();
		}

		public async Task<int> Update(T entity) {
			var theType = entity.GetType();
			var LastModifiedDateTime = theType.GetProperty("LastModifiedDateTime");
			if (LastModifiedDateTime != null) {
				LastModifiedDateTime.SetValue(entity, DateTime.Now);
			}

			TEntity.Update(entity);
			return await _ctx.Instance.SaveChangesAsync();

		}

		public T FindById(object id) {
			var res = TEntity.Find(id);
			return res;
		}
	}
}
