using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories

{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TABLE MAPPING
            modelBuilder.Entity<UserEntity>().HasKey(p => p.Id);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
