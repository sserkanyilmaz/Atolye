using System;
using Atolye.Domain.Common;
using Atolye.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Atolye.Persistence.Context
{
	public class AtolyeDbContext : DbContext
    {
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<CareerStuff> CareerStuffs { get; set; }
        public DbSet<ConsumableInventory> ConsumableInventories { get; set; }
        public DbSet<EngineerOfTheMonth> EngineersOfTheMonths { get; set; }
        public DbSet<FixtureInformation> FixtureInformations { get; set; }
        public DbSet<FixtureInventory> FixtureInventories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public AtolyeDbContext(DbContextOptions<AtolyeDbContext> options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();
            foreach (EntityEntry<BaseEntity> data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                    data.Entity.IsActive = true;
                }
                else if (data.State == EntityState.Modified)
                    data.Entity.UpdatedDate = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Persons");
                entity.HasOne(p => p.Team)
                      .WithMany(t => t.Members)
                      .HasForeignKey(p => p.TeamId)
                      .IsRequired(false);
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(t => t.Project)
                      .WithOne(p => p.Team)
                      .HasForeignKey<Project>(p => p.TeamId);
            });
        }

    }
}

