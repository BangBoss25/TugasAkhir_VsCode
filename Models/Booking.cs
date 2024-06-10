using System.ComponentModel.DataAnnotations;

namespace TugasAkhir_VsCode.Models;

public class Booking
{
    [Key]
    public string? VNOPSN { get; set; }
    public string? VNAME { get; set; }
    public string? VNOTELP { get; set; }
    public string? VPROV { get; set; }
    public string? VKAB { get; set; }
    public string? VLOC { get; set; }
    public string? VSTAT { get; set; }
    public DateTime VPSNDate { get; set; }
}