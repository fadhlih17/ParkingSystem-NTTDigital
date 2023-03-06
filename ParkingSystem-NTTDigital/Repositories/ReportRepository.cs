using Microsoft.EntityFrameworkCore;
using ParkingSystem_NTTDigital.Data;
using ParkingSystem_NTTDigital.Entities;

namespace ParkingSystem_NTTDigital.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    public List<LotDetail> GetLotDetailsInclude()
    {
        var lotDetails = _context.LotDetails
            .Include(i => i.LotNumber)
            .OrderBy(i => i.LotNumber.number)
            .ToList();

        return lotDetails;
    }

    public List<LotDetail> FindByVehicleType(EType? find)
    {
        var lotTypes = _context.LotDetails
            .Where(i => i.Type.Equals(find))
            .ToList();
        return lotTypes;
    }

    public List<LotDetail> FindByColor(string color)
    {
        var lotColors = _context.LotDetails
            .Include(i => i.LotNumber)
            .Where(i => i.Color == color)
            .ToList();
        return lotColors;
    }

    public LotDetail FindByRegisNumber(string plat)
    {
        var lotDetail = _context.LotDetails
            .Include(i => i.LotNumber)
            .Where(i => i.Plat.ToUpper() == plat.ToUpper())
            .OrderBy(i => i.LotNumber.number)
            .FirstOrDefault();
        
        return lotDetail;
    }

}