using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParkingSystem_NTTDigital.Entities;

namespace ParkingSystem_NTTDigital.Data;

public class AppDbContext : DbContext
{
    public DbSet<LotNumber> LotNumbers => Set<LotNumber>();
    public DbSet<LotDetail> LotDetails => Set<LotDetail>();
    
    public AppDbContext(DbContextOptions options) : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LotDetail>(builder => builder.HasIndex(detail => detail.Plat).IsUnique());
    }
}