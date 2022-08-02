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
		public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate) {
			var res = -1;

			try {
				var queryresult = TEntity.Where(predicate);

				res = await queryresult.BatchDeleteAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'DeleteAsync'");
			}
			return res;
		}
		public virtual async Task<int> InsertAsync(T entity) {
			var res = -1;

			try {
				var now = DateTime.Now;
				var uId = GetUserId();

				var theType = entity.GetType();
				var createDateTimeProp = theType.GetProperty("CreateDateTime");
				if (createDateTimeProp != null) {
					createDateTimeProp.SetValue(entity, now);
				}

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

				res = await _ctx.Instance.SaveChangesAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'InsertAsync'");
			}

			return res;
		}
		public virtual async Task<int> InsertAsync(List<T> entities) {
			var res = -1;

			try {
				var newEntities = new List<T>();

				var now = DateTime.Now;
				var uId = GetUserId();

				foreach (var entity in entities) {
					var theType = entity.GetType();
					var createDateTimeProp = theType.GetProperty("CreateDateTime");
					if (createDateTimeProp != null) {
						createDateTimeProp.SetValue(entity, now);
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

				if (entities[0] is ShiftLog) {
					_ctx.Instance.ChangeTracker.Entries()
						.Where(e => e.Entity != null).ToList()
						.ForEach(e => e.State = EntityState.Detached);
				}

				await _ctx.Instance.BulkInsertAsync(newEntities);
				res = newEntities.Count;

			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'InsertAsync (Bulk)'");
			}

			return res;
		}
		public virtual async Task<int> UpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression) {
			var res = -1;

			try {
				var queryresult = TEntity.Where(predicate);

				res = await queryresult.BatchUpdateAsync(updateExpression);
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'UpdateAsync (Bulk)'");
			}

			return res;
		}
		public virtual async Task<int> UpdateAsync(T entity) {
			var res = -1;

			try {
				var now = DateTime.Now;
				var uId = GetUserId();

				var theType = entity.GetType();
				var lastModifiedDateTime = theType.GetProperty("LastModifiedDateTime");
				if (lastModifiedDateTime != null) {
					lastModifiedDateTime.SetValue(entity, now);
				}

				if (null != uId) {
					var userId = int.Parse(uId);
					var modifiedByProp = theType.GetProperty("ModifiedBy");
					if (modifiedByProp != null) {
						modifiedByProp.SetValue(entity, userId);
					}
				}

				if (entity is ShiftLog) {
					_ctx.Instance.ChangeTracker.Entries()
						.Where(e => e.Entity != null).ToList()
						.ForEach(e => e.State = EntityState.Detached);
				}

				TEntity.Update(entity);
				res = await _ctx.Instance.SaveChangesAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'UpdateAsync'");
			}

			return res;
		}
		public virtual async Task<StoreViewModel<TResult>> GetAllAsync<TResult, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, bool orderDirectionDesc = true) {
			var res = new StoreViewModel<TResult>();

			try {
				var queryresult = TEntity.Where(predicate);

				if (orderDirectionDesc) {
					queryresult = queryresult.OrderByDescending(orderKeySelector);
				} else {
					queryresult = queryresult.OrderBy(orderKeySelector);
				}

				res.TotalCount = await queryresult.CountAsync();

				res.Result = await queryresult.Select(selectList).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllAsync'");
			}

			return res;
		}
		public virtual async Task<StoreViewModel<TResult>> GetAllAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, bool orderDirectionDesc = true) {
			var res = new StoreViewModel<TResult>();

			try {
				IQueryable<T> queryresult = TEntity;

				for (var i = 0; i < predicate.Count; i++) {
					queryresult = queryresult.Where(predicate[i]);
				}

				if (orderDirectionDesc) {
					queryresult = queryresult.OrderByDescending(orderKeySelector);
				} else {
					queryresult = queryresult.OrderBy(orderKeySelector);
				}

				res.TotalCount = await queryresult.CountAsync();

				res.Result = await queryresult.Select(selectList).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllAsync'");
			}

			return res;
		}

		public virtual async Task<StoreViewModel<TResult>> GetAllWithPagingAsync<TResult, TKey>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, Expression<Func<T, TKey>> orderKeySelector, bool orderDirectionDesc = true, int pageSize = 10, int pageNumber = 0) {
			var res = new StoreViewModel<TResult>();

			try {
				IQueryable<T> queryresult = TEntity;

				for (var i = 0; i < predicate.Count; i++) {
					queryresult = queryresult.Where(predicate[i]);
				}

				if (orderDirectionDesc) {
					queryresult = queryresult.OrderByDescending(orderKeySelector);
				} else {
					queryresult = queryresult.OrderBy(orderKeySelector);
				}

				res.TotalCount = await queryresult.CountAsync();

				res.Result = await queryresult.Select(selectList).Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllWithPagingAsync'");
			}

			return res;
		}

		public virtual async Task<StoreViewModel<TResult>> GetAllWithPagingAsync<TResult>(List<Expression<Func<T, bool>>> predicate, Expression<Func<T, TResult>> selectList, string orderKeySelector, bool orderDirectionDesc = true, int pageSize = 10, int pageNumber = 0) {
			var res = new StoreViewModel<TResult>();

			try {
				IQueryable<T> queryresult = TEntity;

				for (var i = 0; i < predicate.Count; i++) {
					queryresult = queryresult.Where(predicate[i]);
				}

				var type = typeof(T);
				var property = type.GetProperty(orderKeySelector ?? "id", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ?? type.GetProperties().FirstOrDefault(x => x.GetCustomAttribute(typeof(KeyAttribute), true) != null) ?? type.GetProperties().First();

				if (orderDirectionDesc) {
					queryresult = queryresult.OrderByExtended(property.Name, true);
				} else {
					queryresult = queryresult.OrderByExtended(property.Name, false);
				}

				res.TotalCount = await queryresult.CountAsync();

				res.Result = await queryresult.Select(selectList).Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'GetAllWithPagingAsync'");
			}

			return res;
		}

		public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) {
			var res = false;

			try {
				var queryresult = TEntity.Where(predicate);

				res = await queryresult.AnyAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'AnyAsync'");
			}

			return res;
		}

		public virtual async Task<bool> AnyAsync(List<Expression<Func<T, bool>>> predicate) {
			var res = false;

			try {
				IQueryable<T> queryresult = TEntity;

				for (var i = 0; i < predicate.Count; i++) {
					queryresult = queryresult.Where(predicate[i]);
				}

				res = await queryresult.AnyAsync();
			} catch (Exception ex) {
				_logger.Error(ex, "db error, method: 'AnyAsync'");
			}

			return res;
		}

		//public virtual IQueryable<T> GetAll() {

		//	IQueryable<T> query = TEntity;
		//	return query;
		//}

		public virtual List<Expression<Func<T, bool>>> ExpressionMaker() {
			return new List<Expression<Func<T, bool>>>();
		}
		public virtual void Dispose() {
			_ctx.Instance.Dispose();
			
			GC.SuppressFinalize(this);
		}

		public virtual async ValueTask<T?> FindByIdAsync(object id) {
			var res = await TEntity.FindAsync(id);

			return res;
		}
		public virtual async Task<T?> FindByIdAsync(Expression<Func<T, bool>> predicate) {
			//var res = await TEntity.FindAsync(id);
			var res = await TEntity.FirstOrDefaultAsync(predicate);

			return res;
		}

		public virtual string? GetUserId() {
			var ident = _iPrincipal as ClaimsPrincipal;
			var uId = ident?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

			return uId;
		}


	}
}
