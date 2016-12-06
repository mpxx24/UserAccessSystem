using System.Data.Entity;
using UserAccessSystem.DatabaseAccess.Models;

namespace UserAccessSystem.DatabaseAccess {
    public class AppContext : DbContext {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppContext>());
            base.OnModelCreating(modelBuilder);
        }
    }
}