using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspNetNg.DAL
{
    public abstract class RepositoryBase<C> : IDisposable, IGenericRepository
            where C : DbContext, new()
    {
        protected C _dataContext;

        protected C DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = new C());
            }
        }

        protected RepositoryBase()
        {
        }

        protected RepositoryBase(string connection)
        {
            DataContext.Database.Connection.ConnectionString = connection;
        }

        public void Dispose()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }

        public virtual T Single<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                return DataContext.Set<T>().FirstOrDefault(predicate);
            }
            throw new ApplicationException("A predicate is needed");
        }

        public virtual async Task<T> SingleAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                return await DataContext.Set<T>().FirstOrDefaultAsync(predicate);
            }
            throw new ApplicationException("A predicate is needed");
        }

        public virtual async Task<T> SingleOrLocalAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ApplicationException("A predicate is needed");
            T result = Local<T>().AsQueryable().SingleOrDefault(predicate);
            if (result == null) result = await DataContext.Set<T>().FirstOrDefaultAsync(predicate);
            return result;
        }

        public virtual T Single<T>(Expression<Func<T, bool>> predicate, string includeTable) where T : class
        {
            if (predicate != null)
            {
                return DataContext.Set<T>().Include(includeTable).Where(predicate).FirstOrDefault(predicate);
            }
            throw new ApplicationException("A predicate is needed");
        }

        public virtual async Task<T> SingleAsync<T>(Expression<Func<T, bool>> predicate, string includeTable) where T : class
        {
            if (predicate != null)
            {
                return await DataContext.Set<T>().Include(includeTable).Where(predicate).FirstOrDefaultAsync(predicate);
            }
            throw new ApplicationException("A predicate is needed");
        }

        public virtual T GetById<T>(int id) where T : class
        {
            return DataContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            return await DataContext.Set<T>().FindAsync(id);
        }

        public virtual bool Any<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Any(predicate);
        }

        public virtual async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await DataContext.Set<T>().AnyAsync(predicate);
        }

        public virtual IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                return DataContext.Set<T>().Where(predicate);
            }
            throw new ApplicationException("A predicate is needed");
        }

        public virtual IQueryable<T> Query<T>() where T : class
        {
            return DataContext.Set<T>().AsQueryable<T>();
        }

        public virtual IQueryable<T> QueryNoTracking<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                return DataContext.Set<T>().AsNoTracking().Where(predicate);
            }
            throw new ApplicationException("A predicate is needed");
        }

        public virtual IQueryable<T> GetAll<T>() where T : class
        {
            return DataContext.Set<T>();
        }

        public virtual bool Save<T>(T entity) where T : class
        {
            DataContext.Set<T>().Add(entity);
            return DataContext.SaveChanges() > 0;
        }

        public async virtual Task<bool> SaveAsync<T>(T entity) where T : class
        {
            DataContext.Set<T>().Add(entity);
            return await DataContext.SaveChangesAsync() > 0;
        }

        public async virtual Task<bool> SaveRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            DataContext.Set<T>().AddRange(entities);
            return await DataContext.SaveChangesAsync() > 0;
        }

        public virtual bool Update<T>(T entity) where T : class
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
            return DataContext.SaveChanges() > 0;
        }

        public virtual void UpdateNoSave<T>(T entity) where T : class
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public async virtual Task<bool> UpdateAsync<T>(T entity) where T : class
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
            return await DataContext.SaveChangesAsync() > 0;
        }

        public virtual bool Delete<T>(T entity) where T : class
        {
            DataContext.Set<T>().Remove(entity);
            return DataContext.SaveChanges() > 0;
        }

        public virtual void DeleteNoSave<T>(T entity) where T : class
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Set<T>().Remove(entity);
        }

        public async virtual Task<bool> DeleteAsync<T>(T entity) where T : class
        {
            DataContext.Set<T>().Remove(entity);
            return await DataContext.SaveChangesAsync() > 0;
        }

        public virtual bool DeleteAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                IQueryable<T> toBeDeleted = DataContext.Set<T>().Where(predicate);
                DataContext.Set<T>().RemoveRange(toBeDeleted);
                return DataContext.SaveChanges() > 0;
            }
            else
            {
                throw new ApplicationException("A predicate is needed");
            }
        }

        public async virtual Task<bool> DeleteAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                IQueryable<T> toBeDeleted = DataContext.Set<T>().Where(predicate);
                DataContext.Set<T>().RemoveRange(toBeDeleted);
                return await DataContext.SaveChangesAsync() > 0;
            }
            else
            {
                throw new ApplicationException("A predicate is needed");
            }
        }

        public async virtual Task<bool> DeleteAllAsync<T>() where T : class
        {
            DataContext.Set<T>().RemoveRange(DataContext.Set<T>());
            return await DataContext.SaveChangesAsync() > 0;
        }

        public bool Exists<T>(T entity) where T : class
        {
            return DataContext.Set<T>().Local.Any(e => e == entity);
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await DataContext.SaveChangesAsync() > 0;
        }

        public virtual void Attach<T>(T entity) where T : class
        {
            DataContext.Set<T>().Attach(entity);
        }

        public virtual void SetConnection(string connection)
        {
            DataContext.Database.Connection.ConnectionString = connection;
        }

        public T Add<T>(T entity) where T : class
        {
            return DataContext.Set<T>().Add(entity);
        }

        public void DetachAll()
        {
            foreach (DbEntityEntry dbEntityEntry in DataContext.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }

        public void SetProxyCreation(bool value)
        {
            DataContext.Configuration.ProxyCreationEnabled = value;
        }

        public void SetLazyLoading(bool value)
        {
            DataContext.Configuration.LazyLoadingEnabled = value;
        }


        public void Remove<T>(T entity) where T : class
        {
            DataContext.Set<T>().Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            DataContext.Set<T>().RemoveRange(entities);
        }


        public void RemoveAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                IQueryable<T> toBeDeleted = DataContext.Set<T>().Where(predicate);
                DataContext.Set<T>().RemoveRange(toBeDeleted);
            }
            else
            {
                throw new ApplicationException("A predicate is needed");
            }
        }

        public ObservableCollection<T> Local<T>() where T : class
        {
            return DataContext.Set<T>().Local;
        }
    }
}