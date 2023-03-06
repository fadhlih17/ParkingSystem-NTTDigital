using ParkingSystem_NTTDigital.Entities;

namespace ParkingSystem_NTTDigital.Repositories;

public interface IReportRepository
{
    List<LotDetail> GetLotDetailsInclude();
    List<LotDetail> FindByVehicleType(EType? find);
    List<LotDetail> FindByColor(string color);
    LotDetail FindByRegisNumber(string plat);
}