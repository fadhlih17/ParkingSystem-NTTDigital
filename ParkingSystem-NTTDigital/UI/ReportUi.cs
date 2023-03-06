using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using ParkingSystem_NTTDigital.Data;
using ParkingSystem_NTTDigital.Dtos;
using ParkingSystem_NTTDigital.Entities;
using ParkingSystem_NTTDigital.Repositories;
using ParkingSystem_NTTDigital.Services;

namespace ParkingSystem_NTTDigital.UI;

public class ReportUi
{
    private readonly ITransactionService _transactionService;
    private readonly IReportService _reportService;

    public ReportUi(ITransactionService transactionService, IReportService reportService)
    {
        _transactionService = transactionService;
        _reportService = reportService;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Report Menu ====");
            Console.WriteLine("1. Report Of The Lot Filled Numbers");
            Console.WriteLine("2. Check Available Lot");
            Console.WriteLine("3. Check Registration Numbers by Odd Registration Number");
            Console.WriteLine("4. Check Registration Numbers by Even Registration Number");
            Console.WriteLine("5. Total Vehicles by Vehicle's type");
            Console.WriteLine("6. Check Lot Numbers by Color");
            Console.WriteLine("7. Check Registration Numbers by Color");
            
            
            Console.WriteLine("0. Exit");
            try
            {
                Console.Write("Choose : ");
                var choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    case 1 : 
                        ReportOfTheLotFilledNumbers();
                        Console.ReadKey();
                        break;
                    case 2 :
                        AvailableLot();
                        Console.ReadKey();
                        break;
                    case 3 :
                        CheckByOddPlat();
                        Console.ReadKey();
                        break;
                    case 4 : 
                        CheckByEvenPlat();
                        Console.ReadKey();
                        break;
                    case 5 : 
                        TotalVehiclesByVehicleType();
                        Console.ReadKey();
                        break;
                    case 6 :
                        SlotNumberByColor();
                        Console.ReadKey();
                        break;
                    case 7 : 
                        RegisNumberByColor();
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
    public void ReportOfTheLotFilledNumbers()
    {
        var reports = _reportService.ReportOfTheLotFilledNumbers();
        
        Console.WriteLine("Slot\t Plat No \t Type \t Color");
        foreach (var response in reports)
        {
            Console.WriteLine($"{response.Slot}\t {response.PlatNumber} \t{response.Type} \t{response.Color}");
        }

        Console.WriteLine();
    }

    public void AvailableLot()
    {
        var emptyLotNumbers = _transactionService.GetEmptyLotNumbers();
        
        Console.Write("Empty lot numbers : ");
        foreach (var emptyLotNumber in emptyLotNumbers)
        {
            Console.Write($"{emptyLotNumber} ");
        }

        Console.WriteLine();
    }

    public void CheckByOddPlat()
    {
        var responses = _reportService.CheckByOddPlat();
        foreach (var response in responses)
        {
            Console.Write($"{response} ");
        }

        Console.WriteLine();
    }
    
    public void CheckByEvenPlat()
    {
        var responses = _reportService.CheckByEvenPlat();
        foreach (var response in responses)
        {
            Console.Write($"{response} ");
        }

        Console.WriteLine();
    }

    public void TotalVehiclesByVehicleType()
    {
        Console.Write("Input Type (Motor/Mobil)  : ");
        string type = Console.ReadLine();
        Console.WriteLine(_reportService.TotalByVehicleType(type));
    }
    
    public void SlotNumberByColor()
    {
        Console.Write("Input Color : ");
        string color = Console.ReadLine();

        var colors = _reportService.SlotNumberByColor(color);
        foreach (var s in colors)
        {
            Console.Write($"{s}, ");
        }
        Console.WriteLine();
        
    }
    
    public void RegisNumberByColor()
    {
        Console.Write("Input Color : ");
        string color = Console.ReadLine();

        var colors = _reportService.RegisNumberByColor(color);
        foreach (var s in colors)
        {
            Console.Write($"{s}, ");
        }
        Console.WriteLine();
    }

    public void FindLotByRegisNumber()
    {
        Console.Write("Input Registration Number : ");
        string plat = Console.ReadLine();

        var regisNumbers = _reportService.FindLotByRegisNumber(plat);

        Console.WriteLine("=> " + regisNumbers);
    }
}