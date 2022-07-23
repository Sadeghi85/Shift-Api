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
using System.Linq.Dynamic.Core;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

		//public Task<int> SaveChangesAsync() {
		//	var res = Task.FromResult(-1);
		//	try {
		//		res = _ctx.Instance.SaveChangesAsync();
		//	} catch (Exception ex) {
		//		_logger.Error(ex, "db error, method: 'SaveChangesAsync'");
		//	}
		//	return res;
		//}

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
		public virtual Task<int> UpdateAsync(T entity) {
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
			return _ctx.Instance.SaveChangesAsync();
		}
		public virtual Task<List<TResult>> GetAllAsync<TResult, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection, out int totalCount) {
			var res = Task.FromResult(new List<TResult>());
			totalCount = 0;

			try {
				var queryresult = TEntity.Where(predicate);

				if (orderDirection == "asc") {
					queryresult = queryresult.OrderBy(orderKeySelector);
				} else {
					queryresult = queryresult.OrderByDescending(orderKeySelector);
				}

				totalCount = queryresult.Count();

				res = queryresult.Select(selectList).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllAsync'");
			}
			return res;
		}
		public virtual Task<List<TResult>> GetAllAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection, out int totalCount) {
			var res = Task.FromResult(new List<TResult>());
			totalCount = 0;

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

				totalCount = queryresult.Count();

				res = queryresult.Select(selectList).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllAsync'");
			}
			return res;
		}

		public virtual Task<List<TResult>> GetAllWithPagingAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, string orderDirection, int pageSize, int pageNumber, out int totalCount) {
			var res = Task.FromResult(new List<TResult>());
			totalCount = 0;

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

				totalCount = queryresult.Count();

				res = queryresult.Select(selectList).Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllWithPagingAsync'");
			}

			return res;
		}

		public virtual Task<List<TResult>> GetAllWithPagingAsync<TResult>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, string orderKeySelector, string orderDirection, int pageSize, int pageNumber, out int totalCount) {
			var res = Task.FromResult(new List<TResult>());
			totalCount = 0;

			try {
				IQueryable<T> queryresult = TEntity;

				for (var i = 0; i < predicate.Count; i++) {
					queryresult = queryresult.Where(predicate[i]);
				}


				var type = typeof(T);
				var property = type.GetProperty(orderKeySelector ?? "id", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ?? type.GetProperties().FirstOrDefault(x => x.GetCustomAttribute(typeof(KeyAttribute), true) != null) ?? type.GetProperties().First();

				if (orderDirection == "asc") {
					queryresult = queryresult.OrderByExtended(property.Name, false);
				} else {
					queryresult = queryresult.OrderByExtended(property.Name, true);
				}

				totalCount = queryresult.Count();

				res = queryresult.Select(selectList).Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllWithPagingAsync'");
			}

			return res;
		}

		public virtual IQueryable<T> GetAll() {

			IQueryable<T> query = TEntity;
			return query;
		}

		public virtual List<Expression<Func<T, bool>>> ExpressionMaker() {
			return new List<Expression<Func<T, bool>>>();
		}
		public virtual void Dispose() {
			_ctx.Instance.Dispose();
		}

		public virtual ValueTask<T?> FindByIdAsync(object id) {
			var res = TEntity.FindAsync(id);
			return res;
		}

		public virtual string? GetUserId() {
			var ident = _iPrincipal as ClaimsPrincipal;
			var uId = ident?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
			return uId;
		}

		
	}
}
