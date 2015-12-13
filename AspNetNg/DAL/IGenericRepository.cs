using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspNetNg.DAL
{
    public interface IGenericRepository
    {
        T GetById<T>(int id) where T : class;
        T Single<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> Query<T>() where T : class;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> QueryNoTracking<T>(Expression<Func<T, bool>> predicate) where T : class;
        bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        T Save<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        void UpdateNoSave<T>(T entity) where T : class;
        bool Delete<T>(T entity) where T : class;
        void DeleteNoSave<T>(T entity) where T : class;
        bool DeleteAll<T>(Expression<Func<T, bool>> predicate) where T : class;
        bool Exists<T>(T entity) where T : class;
        void SaveChanges();
        ObservableCollection<T> Local<T>() where T : class;

        void DetachAll();
        void Attach<T>(T entity) where T : class;
        T Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;
        void RemoveAll<T>(Expression<Func<T, bool>> predicate) where T : class;

        //async counterparts of the methods
        Task<T> GetByIdAsync<T>(int id) where T : class;
        Task<T> SingleAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> SingleOrLocalAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> SingleAsync<T>(Expression<Func<T, bool>> predicate, string includeTable) where T : class;
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<bool> SaveAsync<T>(T entity) where T : class;
        Task<bool> SaveRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task<bool> UpdateAsync<T>(T entity) where T : class;
        Task<bool> DeleteAsync<T>(T entity) where T : class;
        Task<bool> DeleteAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<bool> DeleteAllAsync<T>() where T : class;
        Task<bool> SaveChangesAsync();

        void SetConnection(string connection);
        void SetProxyCreation(bool value);
        void SetLazyLoading(bool value);
    }
}