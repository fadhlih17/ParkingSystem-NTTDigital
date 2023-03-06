using ParkingSystem_NTTDigital.UI;

namespace ParkingSystem_NTTDigital;

public class App
{
    private CheckInUi _checkInUi;
    private ReportUi _reportUi;

    public App(CheckInUi checkInUi, ReportUi reportUi)
    {
        _checkInUi = checkInUi;
        _reportUi = reportUi;
    }
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Parking System ====");
            Console.WriteLine("1. Make Lot");
            Console.WriteLine("2. Check In");
            Console.WriteLine("3. Checkout");
            Console.WriteLine("4. Report");
            Console.WriteLine("5. Find Lot By Registration Number");
            Console.WriteLine("0. Exit");
            try
            {
                Console.Write("Choose : ");
                var choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    case 1 : 
                        _checkInUi.CreateParkingLot();
                        Console.ReadKey();
                        break;
                    case 2 :
                        _checkInUi.InputParkingLot();
                        Console.ReadKey();
                        break;
                    case 3 :
                        _checkInUi.Checkout();
                        Console.ReadKey();
                        break;
                    case 4 :
                        _reportUi.Run();
                        Console.ReadKey();
                        break;
                    case 5 : 
                        _reportUi.FindLotByRegisNumber();
                        Console.ReadKey();
                        break;
                    case 0 :
                        return;
                    default:
                        Console.WriteLine("No Choices");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.ReadKey();
            }
        }

    }
}