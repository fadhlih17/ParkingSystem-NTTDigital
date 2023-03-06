using ParkingSystem_NTTDigital.Entities;
using ParkingSystem_NTTDigital.Repositories;

namespace ParkingSystem_NTTDigital.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly IPersistence _persistence;

    public TransactionService(ITransactionRepository repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public string CreateParkingLot(int lots)
    {
        var numbers = _repository.FindAllNumbers();
        
        if (numbers.Count > 0)
        {
            Console.Write("Parking lot has been made, Do you want add more (y/t) ? ");
            char choose = Char.Parse(Console.ReadLine());
            if (choose == 'y')
            {
                for (int i = 1; i <= lots; i++)
                {
                    var lot = new LotNumber();
                    lot.number = i + numbers.Count;
                    _repository.AddParkingLot(lot);
                    _persistence.SaveChanges();
                }

                return $"Update parking slot, with total {numbers.Count + lots} slots";
            }
            if(choose == 't')
            {
                return "cancelled add more";
            }
        }

        
        try
        {
            if (numbers.Count == 0)
            {
                for (int i = 1; i <= lots; i++)
                {
                    var lot = new LotNumber();
                    lot.number = i;
                    _repository.AddParkingLot(lot);
                    _persistence.SaveChanges();
                }
            }
            return $"Created a parking lot with {lots} slots";
        }
        catch (Exception e)
        {
            return "Error Created parking lot";
        }
    }

    public string InputParkingLot(string detail)
    {
        string[] datas = detail.Split(" ");
        string plat = datas[0];
        string color = datas[1];
        EType type = EType.Mobil;
        if (datas[2].Equals(EType.Motor.ToString(), StringComparison.OrdinalIgnoreCase))
        {
            type = EType.Motor;
        }
        else if (datas[2].Equals(EType.Mobil.ToString(), StringComparison.OrdinalIgnoreCase))
        {
            type = EType.Mobil;
        }
        else
        {
            Console.WriteLine("error");
        }

        var emptyLots = _repository.GetEmptyLots();
        var emptyLotNumber = GetEmptyLotNumbers();
        
        if (emptyLots.Count == 0)
        {
            return "Sorry, parking lot is Full";
        }

        var saveDetail = new LotDetail
        {
            Plat = plat,
            Type = type,
            TimeIn = DateTime.Now,
            Color = color,
            LotNumberId = emptyLots[0]
        };
        
        _repository.AddLotDetail(saveDetail);
        _persistence.SaveChanges();
        return $"Allocated slot number : " + emptyLotNumber[0];
    }

    public string CheckOut(int numOfLot)
    {
        var lotDetail = _repository.FindLot(numOfLot);
        
        if (lotDetail is null)
        {
            return "Vehicle not found";
        }
        _repository.DeleteFindDetail(lotDetail);
        _persistence.SaveChanges();
        return $"Slot number {lotDetail.LotNumber.number} is free";
    }

    public List<int> GetEmptyLotNumbers()
    {
        var emptyLotNumbers = _repository.GetEmptyLotNumbers();
        
        if (emptyLotNumbers.Count == 0)
        {
            Console.WriteLine("Parking lot is full");
        }

        return emptyLotNumbers;
    }
}