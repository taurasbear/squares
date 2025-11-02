using Microsoft.EntityFrameworkCore;
using Squares.Domain.Entities;

namespace Squares.Infrastructure.Data;

public class SquaresContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Point> Points { get; set; }

    public DbSet<PointSet> PointSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Point>()
            .HasOne(point => point.PointSet)
            .WithMany(pointSet => pointSet.Points)
            .HasForeignKey(point => point.PointSetId);
    }
}