using ParkingSystem_NTTDigital.Services;

namespace ParkingSystem_NTTDigital.UI;

public class CheckInUi
{
    private readonly ITransactionService _service;

    public CheckInUi(ITransactionService service)
    {
        _service = service;
    }
    
    public void CreateParkingLot()
    {
        Console.Write("Create Parking Lot : ");
        int lots = int.Parse(Console.ReadLine());

        Console.WriteLine(_service.CreateParkingLot(lots));
    }

    public void InputParkingLot()
    {
        Console.Write("Input vehicle (B-0000-xxx Putih Motor) : ");
        string detail = Console.ReadLine();
        
        Console.WriteLine(_service.InputParkingLot(detail));
        Console.WriteLine();
    }

    public void Checkout()
    {
        Console.Write("Input Checkout : ");
        int outNum = int.Parse(Console.ReadLine());

        Console.WriteLine(_service.CheckOut(outNum));
        Console.WriteLine();
    }
}