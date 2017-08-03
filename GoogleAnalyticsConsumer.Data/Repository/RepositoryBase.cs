using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace GoogleAnalyticsConsumer.Data
{
    public class RepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public Expression<Func<TEntity, bool>> Filter { get; set; }
        public IEnumerable<TEntity> GetAll()
        {
            using (MainContext DbContext = new MainContext())
            {
                var dbSet = DbContext.Set<TEntity>();
                return dbSet.ToList();
            }
        }
        public DateTime GetLastRecordDate()
        {
            using (MainContext DbContext = new MainContext())
            {
                var dbSet = DbContext.Set<TEntity>();
                var dbQuery = dbSet.AsQueryable();
                var record = dbQuery.OrderByDescending(e => e.DataTime).Take(1).FirstOrDefault();
                if (record != null)
                {
                    return record.DataTime;
                }
                return DateTime.Now;
            }
        }
        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> func, IList<string> includedEntities = null)
        {
            using (MainContext DbContext = new MainContext())
            {
                var dbSet = DbContext.Set<TEntity>();
                var dbQuery = dbSet.AsQueryable();

                if (includedEntities != null)
                {
                    dbQuery = IncludeChildEntities(dbQuery, includedEntities);
                }

                return dbQuery.Where(func).ToList();
            }
        }
        public TEntity GetByID(int id)
        {
            using (MainContext DbContext = new MainContext())
            {
                var dbSet = DbContext.Set<TEntity>();
                return dbSet.Find(id);
            }
        }
        public int Insert(TEntity obj)
        {
            int result = -1;
            using (MainContext DbContext = new MainContext())
            {
                try
                {
                    var dbSet = DbContext.Set<TEntity>();
                    DbContext.Entry(obj).State = EntityState.Added;
                    var entity = dbSet.Add(obj);
                    DbContext.Configuration.AutoDetectChangesEnabled = false;
                    DbContext.Configuration.ValidateOnSaveEnabled = false;
                    DbContext.SaveChanges();
                    result = (int)obj.GetType().GetProperty("Id").GetValue(obj);
                }
                catch (DbEntityValidationException ex)
                {
                    var errors = ex.EntityValidationErrors
                    .SelectMany(eve => eve.ValidationErrors, (eve, ve) => "{ve.PropertyName}: {ve.ErrorMessage}");
                }
            }

            return result;
        }
        public void Insert(IEnumerable<TEntity> entities)
        {
            using (MainContext DbContext = new MainContext())
            {
                var dbSet = DbContext.Set<TEntity>();
                dbSet.AddRange(entities);
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Configuration.ValidateOnSaveEnabled = false;
                DbContext.SaveChanges();
            }
        }
        public void Update(TEntity obj)
        {
            using (MainContext DbContext = new MainContext())
            {
                DbContext.Entry(obj).State = EntityState.Modified;
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Configuration.ValidateOnSaveEnabled = false;
                DbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (MainContext DbContext = new MainContext())
            {
                var dbSet = DbContext.Set<TEntity>();
                var entity = GetByID(id);
                dbSet.Remove(entity);
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Configuration.ValidateOnSaveEnabled = false;
                DbContext.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            using (MainContext DbContext = new MainContext())
            {
                var dbSet = DbContext.Set<TEntity>();
                var dbQuery = dbSet.AsQueryable();
                var entities = dbQuery.ToList();
                dbSet.RemoveRange(entities);
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Configuration.ValidateOnSaveEnabled = false;
                DbContext.SaveChanges();
            }
        }
        public void Truncate(string tableName)
        {
            using (MainContext DbContext = new MainContext())
            {
                DbContext.Database.ExecuteSqlCommand(string.Format("DELETE from {0}", tableName));
            }
        }
        private IQueryable<TEntity> IncludeChildEntities(IQueryable<TEntity> dbQuery, IList<string> includedEntities)
        {
            foreach (var includedEntity in includedEntities)
            {
                dbQuery = dbQuery.Include(includedEntity);
            }

            return dbQuery;
        }
    }
}