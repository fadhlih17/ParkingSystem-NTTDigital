using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem_NTTDigital.Entities;

[Table(name:"lot_detail")]
public class LotDetail
{
    [Key]
    public Guid Id { get; set; }
    public string Plat { get; set; }
    public EType Type { get; set; }
    public DateTime TimeIn { get; set; }
    public string Color { get; set; }
    public Guid LotNumberId { get; set; }
    public virtual LotNumber LotNumber { get; set; }
}