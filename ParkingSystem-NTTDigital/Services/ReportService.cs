using System.Text.RegularExpressions;
using ParkingSystem_NTTDigital.Dtos;
using ParkingSystem_NTTDigital.Entities;
using ParkingSystem_NTTDigital.Repositories;

namespace ParkingSystem_NTTDigital.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _repository;

    public ReportService(IReportRepository repository)
    {
        _repository = repository;
    }

    public List<ReportResponse> ReportOfTheLotFilledNumbers()
    {
        var lotDetails = _repository.GetLotDetailsInclude();
        List<ReportResponse> responses = new List<ReportResponse>();

        if (lotDetails.Count == 0)
        {
            throw new Exception("Not Found");
        }
        
        foreach (var reportLot in lotDetails)
        {
            responses.Add(new ReportResponse
            {
                Slot = reportLot.LotNumber.number,
                PlatNumber = reportLot.Plat,
                Type = reportLot.Type.ToString(),
                Color = reportLot.Color
            });
        }

        return responses;
    }

    public List<string> CheckByOddPlat()
    {
        var lotDetails = _repository.GetLotDetailsInclude();
        List<string> responses = new List<string>();

        if (lotDetails.Count == 0)
        {
            throw new Exception("Registration Number is empty");
        }
        
        foreach (var lotDetail in lotDetails)
        {
            var plats = lotDetail.Plat;
            
            var platNumber = Regex.Match(plats, @"\d+").Value;
            
            if (int.TryParse(platNumber, out int number) && number % 2 != 0)
            {
                responses.Add(plats);
            }

        }

        return responses;
    }
    
    public List<string> CheckByEvenPlat()
    {
        var lotDetails = _repository.GetLotDetailsInclude();
        List<string> responses = new List<string>();
        
        if (lotDetails.Count == 0)
        {
            throw new Exception("Registration Number is empty");
        }
        
        foreach (var lotDetail in lotDetails)
        {
            var plats = lotDetail.Plat;
            
            var platNumber = Regex.Match(plats, @"\d+").Value;
            
            if (int.TryParse(platNumber, out int number) && number % 2 == 0)
            {
                responses.Add(plats);
            }

        }
        
        return responses;
    }

    public string TotalByVehicleType(string type)
    {
        EType? find = null;
        
        if (type.Equals(EType.Mobil.ToString(), StringComparison.OrdinalIgnoreCase))
        {
            find = EType.Mobil;
        }
        else if (type.Equals(EType.Motor.ToString(), StringComparison.OrdinalIgnoreCase))
        {
            find = EType.Motor;
        }

        var findByTypes = _repository.FindByVehicleType(find);

        if (findByTypes.Count == 0)
        {
            return "=> Vehicle Not Found";
        }

        return $"=> {findByTypes.Count}";
    }

    public List<string> SlotNumberByColor(string color)
    {
        var findByColors = _repository.FindByColor(color);
        List<string> responses = new List<string>();
        
        if (findByColors.Count == 0)
        {
            throw new Exception("Lot not found");
        }
        
        foreach (var lotDetail in findByColors)
        {
            responses.Add(lotDetail.LotNumber.number.ToString());
        }

        return responses;
    }

    public List<string> RegisNumberByColor(string color)
    {
        var findByColors = _repository.FindByColor(color);
        List<string> responses = new List<string>();
        
        if (findByColors.Count == 0)
        {
            throw new Exception("Registration Number not found");
        }
        
        foreach (var lotDetail in findByColors)
        {
            responses.Add(lotDetail.Plat);
        }

        return responses;
    }

    public string FindLotByRegisNumber(string plat)
    {
        var detail = _repository.FindByRegisNumber(plat);

        if (detail is null)
        {
            throw new Exception("Not Found");
        }

        return detail.LotNumber.number.ToString();
    }
}