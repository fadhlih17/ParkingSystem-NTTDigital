using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem_NTTDigital.Entities;

[Table(name:"lot_number")]
public class LotNumber
{
    [Key, Column(name:"id")]
    public Guid Id { get; set; }

    [Column(name:"number")]
    public int number { get; set; }
}