using Microsoft.EntityFrameworkCore;
using ParkingSystem_NTTDigital.Data;
using ParkingSystem_NTTDigital.Entities;

namespace ParkingSystem_NTTDigital.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<LotNumber> FindAllNumbers()
    {
        var lots = _context.LotNumbers
            .ToList();
        return lots;
    }
    public List<Guid> GetEmptyLots()
    {
        var emptyLots = _context.LotNumbers
            .Where(lot => !_context.LotDetails.Any(detail => detail.LotNumberId == lot.Id))
            .Select(lot => lot.Id)
            .ToList();
        return emptyLots;
    }

    public List<int> GetEmptyLotNumbers()
    {
        var emptyLotsNum = _context.LotNumbers
            .Where(lot => !_context.LotDetails.Any(detail => detail.LotNumberId == lot.Id))
            .Select(lot => lot.number)
            .ToList();
        return emptyLotsNum;
    }

    public void AddParkingLot(LotNumber lot)
    {
        _context.LotNumbers.Add(lot);
    }

    public void AddLotDetail(LotDetail lotDetail)
    {
        _context.LotDetails.Add(lotDetail);
    }

    public LotDetail? FindLot(int outNum)
    {
        var findLot = _context.LotDetails
            .Include(i => i.LotNumber)
            .FirstOrDefault(i => i.LotNumber.number.Equals(outNum));

        return findLot;
    }

    public void DeleteFindDetail(LotDetail lotDetail)
    {
        _context.LotDetails.Remove(lotDetail);
    }
}