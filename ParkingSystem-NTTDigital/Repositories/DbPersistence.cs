using ParkingSystem_NTTDigital.Data;

namespace ParkingSystem_NTTDigital.Repositories;

public class DbPersistence : IPersistence
{
    private readonly AppDbContext _context;

    public DbPersistence(AppDbContext context)
    {
        _context = context;
    }
    
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}