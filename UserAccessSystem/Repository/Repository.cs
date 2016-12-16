using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UserAccessSystem.DatabaseAccess;

namespace UserAccessSystem.Repository {
    public class Repository : IRepository {
        private readonly DbContext context;

        public Repository() {
            this.context = new AppContext();
        }

        public Repository(DbContext context) {
            this.context = context;
        }

        public void Dispose() {
            this.context?.Dispose();
        }

        public IQueryable<T> GetAll<T>() where T : class {
            return this.context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> func) where T : class {
            return this.context.Set<T>().Where(func).AsQueryable();
        }

        public T GetFirst<T>(Expression<Func<T, bool>> func) where T : class {
            return this.GetAll<T>().FirstOrDefault(func);
        }

        public T Add<T>(T entity) where T : class {
            var obj = this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
            return obj;
        }

        public int Edit<T>(T entity) where T : class {
            try {
                var obj = this.context.Entry(entity);
                this.context.Set<T>().Attach(entity);
                obj.State = EntityState.Modified;
                return this.context.SaveChanges();
            }
            catch (Exception) {
                throw;
            }
        }

        public void Save() {
            this.context.SaveChanges();
        }

        public void Remove<T>(T entity) where T : class {
            this.context.Set<T>().Remove(entity);
            this.context.SaveChanges();
        }
    }
}