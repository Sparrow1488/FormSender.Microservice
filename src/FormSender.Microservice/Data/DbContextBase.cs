using FormSender.Microservice.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FormSender.Microservice.Data
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            DbSaveChangesConfigure();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            DbSaveChangesConfigure();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            DbSaveChangesConfigure();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            DbSaveChangesConfigure();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void DbSaveChangesConfigure()
        {
            AddedEntriesConfigure();
            ModifiedEntriesConfigure();
        }

        private void AddedEntriesConfigure()
        {
            var addedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entity in addedEntries)
            {
                if (entity.Entity is IAuditable)
                {
                    var createdAt = entity.Property(nameof(IAuditable.CreatedAt)).CurrentValue;
                    if (string.IsNullOrWhiteSpace(createdAt?.ToString()) 
                        || DateTime.Parse(createdAt.ToString()).Year < 1970)
                        entity.Property(nameof(IAuditable.CreatedAt)).CurrentValue = DateTime.Now;

                    var updatedAt = entity.Property(nameof(IAuditable.UpdatedAt)).CurrentValue;
                    if (string.IsNullOrWhiteSpace(updatedAt?.ToString())
                        || DateTime.Parse(updatedAt.ToString()).Year < 1970)
                        entity.Property(nameof(IAuditable.UpdatedAt)).CurrentValue = DateTime.Now;
                }
            }
        }

        private void ModifiedEntriesConfigure()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entity in modifiedEntries)
            {
                if (entity.Entity is IAuditable)
                {
                    entity.Property(nameof(IAuditable.UpdatedAt)).CurrentValue = DateTime.Now;
                }
            }
        }
    }
}
