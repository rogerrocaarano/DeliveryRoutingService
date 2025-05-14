using Microsoft.EntityFrameworkCore;
using WebApi.Domain;

namespace WebApi.Persistence;

public class ServiceDbContext : DbContext
{
    public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
    {
    }

    public DbSet<DeliveryRoute> DeliveryRoutes { get; set; }
    public DbSet<DeliveryOrder> Orders { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehiclePosition> VehiclePositions { get; set; }
}