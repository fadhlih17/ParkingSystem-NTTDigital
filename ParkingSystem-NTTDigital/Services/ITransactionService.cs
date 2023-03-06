namespace ParkingSystem_NTTDigital.Services;

public interface ITransactionService
{
    public string CreateParkingLot(int lots);
    string InputParkingLot(string detail);
    string CheckOut(int numOfLot);
    List<int> GetEmptyLotNumbers();
}