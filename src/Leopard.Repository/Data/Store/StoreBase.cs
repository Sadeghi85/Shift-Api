using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Serilog;
using System.Security.Principal;
using System.Security.Claims;

namespace Leopard.Repository {
	public class StoreBase<T> : IStoreBase<T> where T : class, new() {
		protected ILeopardDbContext _ctx;
		protected DbSet<T> TEntity;

		private readonly ILogger _logger;
		private readonly IPrincipal _iPrincipal;

		protected StoreBase(ILeopardDbContext ctx, ILogger logger, IPrincipal principal) {

			_ctx = ctx;
			TEntity = _ctx.Instance.Set<T>();

			_logger = logger;
			_iPrincipal = principal;
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

				var theType = entity.GetType();
				var createDateTimeProp = theType.GetProperty("CreateDateTime");
				if (createDateTimeProp != null) {
					createDateTimeProp.SetValue(entity, DateTime.Now);
				}

				var uId = GetUserId();
				if (null != uId) {
					var userId = int.Parse(uId);
					var createdByProp = theType.GetProperty("CreatedBy");
					if (createdByProp != null) {
						createdByProp.SetValue(entity, userId);
					}
				}

				if (entity is ShiftLog) {
					_ctx.Instance.ChangeTracker.Entries()
						.Where(e => e.Entity != null).ToList()
						.ForEach(e => e.State = EntityState.Detached);
				}

				TEntity.Add(entity);

				res = _ctx.Instance.SaveChangesAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'InsertAsync'");
			}
			return res;
		}

		public string? GetUserId() {
			var ident = _iPrincipal as ClaimsPrincipal;
			var uId = ident?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
			return uId;
		}

		public virtual Task<int> InsertAsync(List<T> entities) {
			var res = Task.FromResult(-1);
			try {
				var newEntities = new List<T>();

				var now = DateTime.Now;
				var uId = GetUserId();

				foreach (var entity in entities) {
					var theType = entity.GetType();
					var createDateTimeProp = theType.GetProperty("CreateDateTime");
					if (createDateTimeProp != null) {
						createDateTimeProp.SetValue(entity, DateTime.Now);
					}

					if (null != uId) {
						var userId = int.Parse(uId);
						var createdByProp = theType.GetProperty("CreatedBy");
						if (createdByProp != null) {
							createdByProp.SetValue(entity, userId);
						}
					}

					newEntities.Add(entity);
				}
				//res = _ctx.Instance.BulkInsert(newEntities);

				res = Task.Run(() => {
					try {

						if (entities.Count == 0) {
							return 0;
						}

						if (entities[0] is ShiftLog) {
							_ctx.Instance.ChangeTracker.Entries()
								.Where(e => e.Entity != null).ToList()
								.ForEach(e => e.State = EntityState.Detached);
						}

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

				IQueryable<T> queryresult = TEntity;

				//if (predicate.Count <= 0) {
				//	return null;
				//}
				//var queryresult = TEntity.Where(predicate[0]);
				//for (int i = 1; i < predicate.Count; i++) {
				//	queryresult = queryresult.Where(predicate[i]);
				//}

				for (var i = 0; i < predicate.Count; i++) {
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

		//public virtual int TotalCount(List<Expression<Func<T, bool>>> predicate) {
		//	var res = 0;
		//	try {
		//		if (predicate.Count <= 0) {
		//			return 0;
		//		}
		//		var queryresult = TEntity.Where(predicate[0]);
		//		for (int i = 1; i < predicate.Count; i++) {
		//			queryresult = queryresult.Where(predicate[i]);
		//		}

		//		res = queryresult.Count();
		//	} catch (Exception ex) {
		//		_logger.Error(ex, "db error, method: 'TotalCount'");
		//	}
		//	return res;
		//}

		public Task<List<TResult>> GetAllWithPagingAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, int pageSize, int pageNumber, string orderDirection, out Task<int> totalCount) {
			var res = Task.FromResult(new List<TResult>());
			totalCount = Task.FromResult(0);

			try {
				IQueryable<T> queryresult = TEntity;

				for (var i = 0; i < predicate.Count; i++) {
					queryresult = queryresult.Where(predicate[i]);
				}

				if (orderDirection == "asc") {
					queryresult = queryresult.OrderBy(orderKeySelector);
				} else {
					queryresult = queryresult.OrderByDescending(orderKeySelector);
				}

				totalCount = queryresult.CountAsync();

				res = queryresult.Select(selectList).Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllWithPagingAsync'");
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
			var lastModifiedDateTime = theType.GetProperty("LastModifiedDateTime");
			if (lastModifiedDateTime != null) {
				lastModifiedDateTime.SetValue(entity, DateTime.Now);
			}

			var uId = GetUserId();
			if (null != uId) {
				var userId = int.Parse(uId);
				var modifiedByProp = theType.GetProperty("ModifiedBy");
				if (modifiedByProp != null) {
					modifiedByProp.SetValue(entity, userId);
				}
			}

			TEntity.Update(entity);
			return await _ctx.Instance.SaveChangesAsync();
		}

		public T? FindById(object id) {
			var res = TEntity.Find(id);
			return res;
		}


	}
}
