using ParkingSystem_NTTDigital.Entities;

namespace ParkingSystem_NTTDigital.Repositories;

public interface ITransactionRepository
{
    List<Guid> GetEmptyLots();
    List<int> GetEmptyLotNumbers();
    void AddParkingLot(LotNumber lot);
    void AddLotDetail(LotDetail lotDetail);
    LotDetail? FindLot(int outNum);
    void DeleteFindDetail(LotDetail lotDetail);
    List<LotNumber> FindAllNumbers();
}