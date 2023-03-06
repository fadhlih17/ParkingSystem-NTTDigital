using ParkingSystem_NTTDigital.Dtos;

namespace ParkingSystem_NTTDigital.Services;

public interface IReportService
{
    List<ReportResponse> ReportOfTheLotFilledNumbers();
    List<string> CheckByOddPlat();
    List<string> CheckByEvenPlat();
    string TotalByVehicleType(string type);
    List<string> SlotNumberByColor(string color);
    List<string> RegisNumberByColor(string color);
    string FindLotByRegisNumber(string plat);
}