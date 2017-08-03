using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace GoogleAnalyticsConsumer.Data
{
    public class RepositoryBase<TEntity> : IDisposable where TEntity : class, IEntity
    {
        public MainContext DbContext;
        public RepositoryBase()
        {
            this.DbContext = new MainContext();
        }

        public Expression<Func<TEntity, bool>> Filter { get; set; }
        public IEnumerable<TEntity> GetAll()
        {
            var dbSet = DbContext.Set<TEntity>();
            return dbSet.ToList();
        }
        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> func, IList<string> includedEntities = null)
        {
                var dbSet = DbContext.Set<TEntity>();
                var dbQuery = dbSet.AsQueryable();

                if (includedEntities != null)
                {
                    dbQuery = IncludeChildEntities(dbQuery, includedEntities);
                }

                return dbQuery.Where(func).ToList();
        }
        public DateTime GetLastRecordDate()
        {
            var dbSet = DbContext.Set<TEntity>();
            var dbQuery = dbSet.AsQueryable();
            var last = dbQuery.OrderByDescending(e => e.DataTime).Take(1).FirstOrDefault();

            if (last != null)
            {
                return last.DataTime;
            }
            return DateTime.Now;
        }
        public TEntity GetByID(int id)
        {
            var dbSet = DbContext.Set<TEntity>();
            return dbSet.Find(id);
        }
        public int Insert(TEntity obj)
        {
            int result = -1;
            try
            {
                var dbSet = DbContext.Set<TEntity>();
                DbContext.Entry(obj).State = EntityState.Added;
                var entity = dbSet.Add(obj);
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Configuration.ValidateOnSaveEnabled = false;
                result = (int)obj.GetType().GetProperty("Id").GetValue(obj);
            }
            catch (DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors
                .SelectMany(eve => eve.ValidationErrors, (eve, ve) => "{ve.PropertyName}: {ve.ErrorMessage}");
            }
            return result;
        }
        public void Insert(IEnumerable<TEntity> entities)
        {
            var dbSet = DbContext.Set<TEntity>();
            dbSet.AddRange(entities);
            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        public void Update(TEntity obj)
        {
            DbContext.Entry(obj).State = EntityState.Modified;
            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        public void Delete(int id)
        {
            var dbSet = DbContext.Set<TEntity>();
            var entity = GetByID(id);
            dbSet.Remove(entity);
            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        public void DeleteAll()
        {
            var dbSet = DbContext.Set<TEntity>();
            var dbQuery = dbSet.AsQueryable();
            var entities = dbQuery.ToList();
            dbSet.RemoveRange(entities);
            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        public void Truncate(string tableName)
        {
            DbContext.Database.ExecuteSqlCommand(string.Format("DELETE from {0}", tableName));
        }
        private IQueryable<TEntity> IncludeChildEntities(IQueryable<TEntity> dbQuery, IList<string> includedEntities)
        {
            foreach (var includedEntity in includedEntities)
            {
                dbQuery = dbQuery.Include(includedEntity);
            }

            return dbQuery;
        }
        public void Dispose()
        {
            if (this.DbContext != null)
            {
                this.DbContext.Dispose();
                this.DbContext = null;
            }
        }
    }
}