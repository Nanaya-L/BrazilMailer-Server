using Microsoft.EntityFrameworkCore;

namespace Repositories

{
    public class PGContext(DbContextOptions<PGContext> options) : DbContext(options)
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add-migration NAME
            //update-database

            #region TABLE MAPPING

            #endregion

            modelBuilder.HasDefaultSchema("public"); // schema configuration
            base.OnModelCreating(modelBuilder);
        }
    }
}