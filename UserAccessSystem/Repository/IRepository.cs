using System;
using System.Linq;
using System.Linq.Expressions;

namespace UserAccessSystem.Repository {
    public interface IRepository : IDisposable {
        IQueryable<T> GetAll<T>() where T : class;
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> func) where T : class;
        T GetFirst<T>(Expression<Func<T, bool>> func) where T : class;
        T Add<T>(T entity) where T : class;
        int Edit<T>(T entity) where T : class;
        void Save();
    }
}