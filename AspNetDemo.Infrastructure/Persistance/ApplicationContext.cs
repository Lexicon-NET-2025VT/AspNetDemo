using AspNetDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDemo.Infrastructure.Persistance;
public class ApplicationContext(DbContextOptions<ApplicationContext> options, ILogger<ApplicationContext> logger)
    : DbContext(options)
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, CompanyName = "Ica", City = "Stockholm" },
            new Company { Id = 22, CompanyName = "Coop", City = "Stockholm" },
            new Company { Id = 3, CompanyName = "Hemköp", City = "Göteborg" }
        );
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entity in modifiedEntries)
        {
            var entityName = entity.Entity.GetType().Name;
            var primaryKey = entity.Properties
                .FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue;

            foreach (var prop in entity.Properties)
            {
                if (prop.IsModified)
                {
                    var original = prop.OriginalValue?.ToString() ?? "null";
                    var current = prop.CurrentValue?.ToString() ?? "null";

                    logger.LogInformation(
                        $"{entityName} ({primaryKey}), {prop.Metadata.Name}: {original} -> {current}");
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}

