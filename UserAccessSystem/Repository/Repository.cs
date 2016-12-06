using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UserAccessSystem.DatabaseAccess;

namespace UserAccessSystem.Repository {
    public class Repository : IRepository {
        private readonly DbContext context;

        public Repository() {
            context = new AppContext();
        }

        public Repository(DbContext context) {
            this.context = context;
        }

        public void Dispose() {
            context?.Dispose();
        }

        public IQueryable<T> GetAll<T>() where T : class {
            return context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> func) where T : class {
            return context.Set<T>().Where(func).AsQueryable();
        }

        public T GetFirst<T>(Expression<Func<T, bool>> func) where T : class {
            return GetAll<T>().FirstOrDefault(func);
        }

        public T Add<T>(T entity) where T : class {
            var obj = context.Set<T>().Add(entity);
            context.SaveChanges();
            return obj;
        }

        public int Edit<T>(T entity) where T : class {
            try {
                var obj = context.Entry(entity);
                context.Set<T>().Attach(entity);
                obj.State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch (Exception) {
                throw;
            }
        }

        public void Save() {
            context.SaveChanges();
        }
    }
}